using Ardalis.Result;
using NewConsig.ApiAppServidor.Application.DTOs;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Application.Services.Interfaces
{
    public interface IConsignacaoService
    {
        Result<List<Consignacao>> GetConsignacoesServidorAsync(long usuarioId, string dbName, CancellationToken ct = default);
        Result<List<ConsignacaoProposta>> GetConsignacoesPropostaServidorAsync(long servidorId, string dbName, CancellationToken ct = default);
        Task<Result> AceitePropostaAsync(AceitePropostaDto aceitePropostaDto);
    }
}
