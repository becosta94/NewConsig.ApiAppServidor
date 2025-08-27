using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class EntradaMargemMap : IEntityTypeConfiguration<EntradaMargem>
    {
        public void Configure(EntityTypeBuilder<EntradaMargem> entity)
        {
            entity.ToTable("EntradasMargem");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.IdServidor)
                    .IsRequired()
                    .HasColumnName("IdServidor")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdServico)
                    .IsRequired()
                    .HasColumnName("IdServico")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.Valor)
                    .IsRequired()
                    .HasColumnName("ValorMargem")
                    .HasColumnType("decimal(13,2)");
            entity.Property(prop => prop.IdProcessamentoArquivo)
                    .IsRequired(false)
                    .HasColumnName("IdProcessamentoArquivo")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdConsignacao)
                    .IsRequired(false)
                    .HasColumnName("IdConsignacao")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdReservaMargem)
                    .IsRequired(false)
                    .HasColumnName("IdReservaMargem")
                    .HasColumnType("bigint");
            entity.HasOne(prop => prop.Consignacao)
                    .WithMany()
                    .HasForeignKey(prop => prop.IdConsignacao);
            entity.HasOne(prop => prop.Servico)
                    .WithMany()
                    .HasForeignKey(prop => prop.IdServico);
            entity.HasOne(prop => prop.Servidor)
                    .WithMany(prop => prop.EntradasMargem)
                    .HasForeignKey(prop => prop.IdServidor);
        }
    }
}
