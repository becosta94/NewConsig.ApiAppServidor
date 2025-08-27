using Ardalis.Result;
using NewConsig.ApiAppServidor.Application.DTOs;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Application.Services;

public interface IUsuarioService
{
    Result<Usuario> AuthAsync(AuthDto auth, CancellationToken ct = default);
    Result<Servidor> GetDadosServidor(long id, string dbName, CancellationToken ct = default);
    Task<Result<Servidor>> ResetarSenha(ResetarSenhaDto resetarSenha, CancellationToken ct = default);
    Result ValidarSenha(ValidarSenhaDto validarSenha, CancellationToken ct = default);
    Task<Result> TrocarSenha(TrocarSenhaDto trocaSenha, CancellationToken ct = default);
}
