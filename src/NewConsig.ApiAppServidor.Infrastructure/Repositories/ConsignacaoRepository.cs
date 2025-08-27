using Microsoft.EntityFrameworkCore;
using NewConsig.ApiAppServidor.Domain.Entities;
using NewConsig.ApiAppServidor.Domain.Repositories;
using NewConsig.ApiAppServidor.Infrastructure.Data;

namespace NewConsig.ApiAppServidor.Infrastructure.Repositories
{
    public class ConsignacaoRepository : IConsignacaoRepository
    {
        private readonly IAppDbContextFactory _ctxFactory;

        public ConsignacaoRepository(IAppDbContextFactory ctxFactory)
        {
            _ctxFactory=ctxFactory;
        }

        public async Task<List<Consignacao>> GetConsignacoesServidorAsync(long servidorId, string dbName, CancellationToken ct = default)
        {
            using var ctx = _ctxFactory.CreateDbContext(dbName);
            return await ctx.Consignacao.AsNoTracking()?
                                    .Include(x => x.Servidor)
                                    .Include(x => x.ConsignacaoHistorico)
                                    .Include(x => x.Evento)
                                    .ThenInclude(x => x.Consignataria)
                                    .Include(x => x.Evento)
                                    .ThenInclude(x => x.Servico)
                                    .Where(x => x.IdServidor == servidorId && x.DataFinalizacao == DateTime.MinValue)
                                    .ToListAsync(ct);
        }

        public async Task<List<ConsignacaoProposta>> GetConsignacoesPropostaServidorAsync(long servidorId, string dbName, CancellationToken ct = default)
        {
            using var ctx = _ctxFactory.CreateDbContext(dbName);
            return await ctx.ConsignacaoProposta.AsNoTracking()?
                                    .Include(x => x.Servidor)
                                    .Include(x => x.Evento)
                                    .ThenInclude(x => x.Consignataria)
                                    .Include(x => x.Evento)
                                    .ThenInclude(x => x.Servico)
                                    .Where(x => x.IdServidor == servidorId && !x.AceiteServidor && !x.Indeferido && !x.Deferido && !x.Expirado)
                                    .ToListAsync(ct);
        }
    }
}
