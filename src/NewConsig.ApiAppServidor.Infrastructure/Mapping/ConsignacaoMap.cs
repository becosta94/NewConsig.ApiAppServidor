using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class ConsignacaoMap : IEntityTypeConfiguration<Consignacao>
    {
        public void Configure(EntityTypeBuilder<Consignacao> entity)
        {
            entity.ToTable("Consignacao");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.IdServidor)
                    .IsRequired()
                    .HasColumnName("IdServidor")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdEvento)
                    .IsRequired()
                    .HasColumnName("IdEvento")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.DataInclusao)
                    .IsRequired()
                    .HasColumnName("DataInclusao")
                    .HasColumnType("datetime2");
            entity.Property(prop => prop.DataFinalizacao)
                    .IsRequired()
                    .HasColumnName("DataFinalizacao")
                    .HasColumnType("datetime2");
            entity.Property(prop => prop.DataInicioDesconto)
                    .IsRequired()
                    .HasColumnName("DataInicioDesconto")
                    .HasColumnType("datetime2");
            entity.Property(prop => prop.Prazo)
                    .IsRequired()
                    .HasColumnName("Prazo")
                    .HasColumnType("int");
            entity.Property(prop => prop.ValorMensal)
                    .IsRequired()
                    .HasColumnName("ValorMensal")
                    .HasColumnType("decimal(13,2)");
            entity.Property(prop => prop.IdProcessamentoArquivo)
                    .HasColumnName("IdProcessamentoArquivo")
                    .HasColumnType("bigint")
                    .IsRequired(false);
            entity.Property(prop => prop.NumeroContratoBanco)
                    .HasColumnName("NumeroContratoBanco")
                    .HasColumnType("VARCHAR(150)")
                    .IsRequired(false);
            entity.HasOne(prop => prop.Evento)
                   .WithMany(prop => prop.Consignacoes)
                   .HasForeignKey(x => x.IdEvento)
                   .IsRequired();
            entity.HasOne(prop => prop.Servidor)
                   .WithMany(prop => prop.Consignacoes)
                   .HasForeignKey(x => x.IdServidor)
                   .IsRequired();
        }
    }
}
