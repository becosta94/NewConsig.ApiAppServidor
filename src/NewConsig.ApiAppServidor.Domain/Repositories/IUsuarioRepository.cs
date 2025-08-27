using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> AuthAsync(string cpf, string senha, string dbName, CancellationToken ct = default);
    Task<Servidor?> GetDadosServidorAsync(long id, string dbName, CancellationToken ct = default);
    Task<Usuario?> GetUsuario(string cpf, string dbName, CancellationToken ct = default);
}
