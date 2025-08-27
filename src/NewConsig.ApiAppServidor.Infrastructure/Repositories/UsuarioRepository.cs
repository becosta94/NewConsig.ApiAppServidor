using Microsoft.EntityFrameworkCore;
using NewConsig.ApiAppServidor.Domain.Entities;
using NewConsig.ApiAppServidor.Domain.Repositories;
using NewConsig.ApiAppServidor.Infrastructure.Data;
using System.Security.Cryptography;
using System.Text;

namespace NewConsig.ApiAppServidor.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IAppDbContextFactory _ctxFactory;

    public UsuarioRepository(IAppDbContextFactory ctxFactory) => _ctxFactory = ctxFactory;

    public async Task<Usuario?> AuthAsync(string cpf, string senha, string dbName, CancellationToken ct = default)
    {
        using var ctx = _ctxFactory.CreateDbContext(dbName);
        var senhaCifrada = Cifrar(senha);
        return await ctx.Usuario.AsNoTracking()?
                    .Include(x => x.Servidores)
                    .ThenInclude(x => x.Secretaria)
                    .Include(x => x.Servidores)
                    .ThenInclude(x => x.VinculoEmpregaticio)
                    .Include(x => x.Servidores)
                    .ThenInclude(x => x.EntradasMargem)
                    .FirstOrDefaultAsync(x => x.Cpf == cpf && x.Senha == senhaCifrada, ct);
    }

    public async Task<Servidor?> GetDadosServidorAsync(long id, string dbName, CancellationToken ct = default)
    {
        using var ctx = _ctxFactory.CreateDbContext(dbName);
        return await ctx.Servidor.AsNoTracking()?
                                .Include(x => x.Secretaria)
                                .Include(x => x.VinculoEmpregaticio)
                                .Include(x => x.Consignacoes)
                                .ThenInclude(x => x.Evento.Servico)
                                .Include(x => x.Consignacoes)
                                .ThenInclude(x => x.Evento.Consignataria)
                                .Include(x => x.Consignacoes)
                                .ThenInclude(x => x.ConsignacaoHistorico)
                                .Include(x => x.EntradasMargem)
                                .ThenInclude(x => x.Servico)
                                .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<Usuario?> GetUsuario(string cpf, string dbName, CancellationToken ct = default)
    {
        using var ctx = _ctxFactory.CreateDbContext(dbName);
        return await ctx.Usuario.AsNoTracking()?.FirstOrDefaultAsync(x => x.Cpf == cpf, ct);
    }

    public string Cifrar(string textoPuro)
    {
        string chaveCifragem = "MACVS2014XYW";
        byte[] bytesLimpos = Encoding.Unicode.GetBytes(textoPuro);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(chaveCifragem, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesLimpos, 0, bytesLimpos.Length);
                    cs.Close();
                }
                textoPuro = Convert.ToBase64String(ms.ToArray());
            }
        }
        return textoPuro;
    }
}
