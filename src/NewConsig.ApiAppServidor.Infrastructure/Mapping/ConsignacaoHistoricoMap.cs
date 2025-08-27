using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class ConsignacaoHistoricoMap : IEntityTypeConfiguration<ConsignacaoHistorico>
    {
        public void Configure(EntityTypeBuilder<ConsignacaoHistorico> entity)
        {
            entity.ToTable("ConsignacaoHistorico");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.IdConsignacao)
                    .IsRequired()
                    .HasColumnName("IdConsignacao")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdProcessamentoArquivo)
                    .IsRequired(false)
                    .HasColumnName("IdProcessamentoArquivo")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.DataPagamento)
                    .IsRequired()
                    .HasColumnName("DataPagamento")
                    .HasColumnType("datetime2");
            entity.Property(prop => prop.NumeroParcelaPaga)
                    .IsRequired()
                    .HasColumnName("NumeroParcelaPaga")
                    .HasColumnType("int");
            entity.Property(prop => prop.ValorPago)
                    .IsRequired(false)
                    .HasColumnName("ValorPago")
                    .HasColumnType("decimal(13,2)");
            entity.HasOne(prop => prop.Consignacao)
                    .WithMany(prop => prop.ConsignacaoHistorico)
                    .HasForeignKey(prop => prop.IdConsignacao);
        }
    }
}
