using Ardalis.Result;
using NewConsig.ApiAppServidor.Application.DTOs;
using NewConsig.ApiAppServidor.Application.Services.Interfaces;
using NewConsig.ApiAppServidor.Domain.Entities;
using NewConsig.ApiAppServidor.Domain.Repositories;

namespace NewConsig.ApiAppServidor.Application.Services
{

    public class ConsignacaoService : IConsignacaoService
    {
        private readonly IConsignacaoRepository _repo;
        private readonly HttpClient _httpClient;
        public ConsignacaoService(IConsignacaoRepository repo, HttpClient httpClient)
        {
            _repo=repo;
            _httpClient=httpClient;
        }

        public Result<List<Consignacao>> GetConsignacoesServidorAsync(long servidorId, string dbName, CancellationToken ct = default)
        {
            var consignacoes = _repo.GetConsignacoesServidorAsync(servidorId, dbName, ct).Result;
            if (consignacoes == null || consignacoes.Count == 0)
                return Result.NotFound("Servidor não tem consignações.");
            else
            {
                foreach (var item in consignacoes)
                {
                    if (item.ConsignacaoHistorico != null && item.ConsignacaoHistorico.Count != 0)
                    {
                        var parcelaMaxima = item.ConsignacaoHistorico.Max(x => x.NumeroParcelaPaga);
                        item.ConsignacaoHistorico.RemoveAll(x => x.NumeroParcelaPaga < parcelaMaxima);
                    }
                }
                return Result.Success(consignacoes);
            }
        }

        public Result<List<ConsignacaoProposta>> GetConsignacoesPropostaServidorAsync(long servidorId, string dbName, CancellationToken ct = default)
        {
            var consignacoesProposta = _repo.GetConsignacoesPropostaServidorAsync(servidorId, dbName, ct).Result;
            if (consignacoesProposta == null || consignacoesProposta.Count == 0)
                return Result.NotFound("Servidor não tem propostas.");
            else
                return Result.Success(consignacoesProposta);
        }

        public async Task<Result> AceitePropostaAsync(AceitePropostaDto aceitePropostaDto)
        {
            try
            {
                if (string.IsNullOrEmpty(aceitePropostaDto.Senha))
                    return Result.Error("Senha não informada.");

                if (long.Parse(aceitePropostaDto.PropostaId) <= 0)
                    return Result.Error("Proposta não informada.");
                var porta = Enum.Parse(typeof(ConvenioEnum), aceitePropostaDto.DbName);
                var url = $"http://localhost:{(int)porta}/ConsignacaoProposta/aceiteservidor?idConsignacaoProposta={aceitePropostaDto.PropostaId}&senhaServidor={aceitePropostaDto.Senha}&idUsuarioCadastrante=0";
                var response = await _httpClient.PutAsync(url, null);

                if (response.IsSuccessStatusCode)
                    return Result.Success();
                else
                    return Result.Error($"Erro: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                return Result.Error("Erro, favor contatar a administração.");
            }
        }
    }
}
