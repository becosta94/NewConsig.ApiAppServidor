using NewConsig.ApiAppServidor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewConsig.ApiAppServidor.Domain.Repositories
{
    public interface IConsignacaoRepository
    {
        Task<List<Consignacao>> GetConsignacoesServidorAsync(long usuarioId, string dbName, CancellationToken ct = default);
        Task<List<ConsignacaoProposta>> GetConsignacoesPropostaServidorAsync(long servidorId, string dbName, CancellationToken ct = default);
    }
}
