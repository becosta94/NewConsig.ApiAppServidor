using Ardalis.Result;
using NewConsig.ApiAppServidor.Application.DTOs;
using NewConsig.ApiAppServidor.Application.Services.Interfaces;
using NewConsig.ApiAppServidor.Domain.Entities;
using NewConsig.ApiAppServidor.Domain.Repositories;

namespace NewConsig.ApiAppServidor.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repo;
    private readonly ITokenServico _tokenServico;
    private readonly HttpClient _httpClient;

    public UsuarioService(IUsuarioRepository repo, ITokenServico tokenServico, HttpClient httpClient)
    {
        _repo = repo;
        _tokenServico=tokenServico;
        _httpClient=httpClient;
    }

    public Result<Usuario> AuthAsync(AuthDto auth, CancellationToken ct = default)
    {
        var usuario = _repo.AuthAsync(auth.Cpf, auth.Senha, auth.DbName, ct).Result;
        if (usuario == null)
            return Result.NotFound("Usuário não encontrado ou senha inválida.");
        else
            return Result.Success(_tokenServico.GerarToken(usuario));
    }

    public Result<Servidor> GetDadosServidor(long id, string dbName, CancellationToken ct = default)
    {
        var servidor = _repo.GetDadosServidorAsync(id, dbName, ct).Result;
        var entradas = servidor.EntradasMargem.GroupBy(x => x.Servico.Id);
        List<EntradaMargem>? margens = new List<EntradaMargem>();
        foreach (var entradaMargem in entradas)
        {
            EntradaMargem margemAgrupada = new EntradaMargem(entradaMargem.First().IdServidor, entradaMargem.First().Servico.Id, entradaMargem.Sum(x => x.Valor), 0);
            margemAgrupada.Servico = entradaMargem.First().Servico;
            margens.Add(margemAgrupada);
        }
        servidor.EntradasMargem.Clear();
        servidor.EntradasMargem.AddRange(margens);
        if (servidor == null)
            return Result.NotFound("Usuário não encontrado ou senha inválida.");
        else
            return Result.Success(servidor);
    }

    public async Task<Result<Servidor>> ResetarSenha(ResetarSenhaDto resetarSenha, CancellationToken ct = default)
    {
        try
        {
            if (string.IsNullOrEmpty(resetarSenha.Cpf))
                return Result.Error("Cpf não informado.");

            if (string.IsNullOrEmpty(resetarSenha.Email))
                return Result.Error("E-mail não informado.");
            var porta = Enum.Parse(typeof(ConvenioEnum), resetarSenha.CodigoCidade);
            var url = $"http://localhost:{(int)porta}/Usuario/controlarsenha?cpf={resetarSenha.Cpf}&email={resetarSenha.Email}&viaSite=false";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
                return Result.Success();
            else if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
            {
                var mensagem = response.Content.ReadAsStringAsync().Result;
                return Result.Error(mensagem);
            }
            else
                return Result.Error("Ocorreu um erro não esperado, contate a administração");
        }
        catch (Exception ex)
        {
            return Result.Error("Erro, favor contatar a administração.");
        }
    }

    public Result ValidarSenha(ValidarSenhaDto validarSenha, CancellationToken ct = default)
    {
        try
        {
            if (string.IsNullOrEmpty(validarSenha.Cpf))
                return Result.Error("Cpf não informado.");

            if (string.IsNullOrEmpty(validarSenha.SenhaEmail))
                return Result.Error("Código não informado.");

            var usuario = _repo.GetUsuario(validarSenha.Cpf.Replace("-","").Replace(".", ""), validarSenha.CodigoCidade, ct).Result;

            if (usuario == null)
                return Result.NotFound("Usuário não encontrado.");
            else if (string.IsNullOrEmpty(usuario.TokenAlteracaoSenha) && usuario.TokenAlteracaoSenha?.Substring(0, 6) != validarSenha.SenhaEmail)
                return Result.Error("Código inválido.");

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Error("Erro, favor contatar a administração.");
        }
    }

    public async Task<Result> TrocarSenha(TrocarSenhaDto trocaSenha, CancellationToken ct = default)
    {
        try
        {
            if (string.IsNullOrEmpty(trocaSenha.NovaSenha))
                return Result.Error("Senha não informada.");

            var usuario = _repo.GetUsuario(trocaSenha.Cpf.Replace("-", "").Replace(".", ""), trocaSenha.CodigoCidade, ct).Result;

            if (usuario == null)
                return Result.NotFound("Usuário não encontrado.");

            var porta = Enum.Parse(typeof(ConvenioEnum), trocaSenha.CodigoCidade);
            var url = $"http://localhost:{(int)porta}/Usuario/esqueciminhasenhaconfirmar?senha={trocaSenha.NovaSenha}&confirmarSenha={trocaSenha.NovaSenha}&token={usuario.TokenAlteracaoSenha}&idUsuario={usuario.Id}";
            var response = await _httpClient.PutAsync(url, null);

            if (response.IsSuccessStatusCode)
                return Result.Success();
            else if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
            {
                var mensagem = response.Content.ReadAsStringAsync().Result;
                return Result.Error(mensagem);
            }
            else
                return Result.Error("Ocorreu um erro não esperado, contate a administração");
        }
        catch (Exception ex)
        {
            return Result.Error("Erro, favor contatar a administração.");
        }
    }
}
