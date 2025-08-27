using Microsoft.EntityFrameworkCore;
using NewConsig.ApiAppServidor.Domain.Entities;
using System.Reflection;

namespace NewConsig.ApiAppServidor.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Consignacao> Consignacao => Set<Consignacao>();
    public DbSet<ConsignacaoHistorico> ConsignacaoHistorico => Set<ConsignacaoHistorico>();
    public DbSet<ConsignacaoProposta> ConsignacaoProposta => Set<ConsignacaoProposta>();
    public DbSet<Consignataria> Consignataria => Set<Consignataria>();
    public DbSet<EntradaMargem> EntradaMargem => Set<EntradaMargem>();
    public DbSet<Evento> Evento => Set<Evento>();
    public DbSet<Secretaria> Secretaria => Set<Secretaria>();
    public DbSet<Servico> Servico => Set<Servico>();
    public DbSet<Servidor> Servidor => Set<Servidor>();
    public DbSet<Usuario> Usuario => Set<Usuario>();
    public DbSet<VinculoEmpregaticio> VinculoEmpregaticio => Set<VinculoEmpregaticio>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
