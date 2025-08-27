using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    internal class ConsignacaoPropostaMap : IEntityTypeConfiguration<ConsignacaoProposta>
    {
        public void Configure(EntityTypeBuilder<ConsignacaoProposta> entity)
        {
            entity.ToTable("ConsignacaoProposta");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.IdEvento)
                    .IsRequired()
                    .HasColumnName("IdEvento")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdServidor)
                    .IsRequired()
                    .HasColumnName("IdServidor")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdUsuarioCadastrante)
                    .IsRequired()
                    .HasColumnName("IdUsuarioCadastrante")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdUsuarioDeferimento)
                    .IsRequired(false)
                    .HasColumnName("IdUsuarioDeferimento")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdConsignacao)
                    .IsRequired(false)
                    .HasColumnName("IdConsignacao")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.Prazo)
                    .IsRequired()
                    .HasColumnName("Prazo")
                    .HasColumnType("int");
            entity.Property(prop => prop.ValorContratado)
                    .IsRequired()
                    .HasColumnName("ValorContratado")
                    .HasColumnType("decimal(13,2)");
            entity.Property(prop => prop.ValorMensal)
                    .IsRequired()
                    .HasColumnName("ValorMensal")
                    .HasColumnType("decimal(13,2)");
            entity.Property(prop => prop.AceiteServidor)
                    .IsRequired()
                    .HasColumnName("AceiteServidor")
                    .HasColumnType("bit");
            entity.Property(prop => prop.Deferido)
                    .IsRequired()
                    .HasColumnName("Deferido")
                    .HasColumnType("bit");
            entity.Property(prop => prop.Indeferido)
                    .IsRequired()
                    .HasColumnName("Indeferido")
                    .HasColumnType("bit");
            entity.Property(prop => prop.Expirado)
                    .IsRequired()
                    .HasColumnName("Expirado")
                    .HasColumnType("bit");
            entity.Property(prop => prop.NumeroContratoBanco)
                    .IsRequired(false)
                    .HasColumnName("NumeroContratoBanco")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.DataAceite)
                    .IsRequired()
                    .HasColumnName("DataAceite")
                    .HasColumnType("datetime2");
            entity.Property(prop => prop.DataDeferimento)
                    .IsRequired()
                    .HasColumnName("DataDeferimento")
                    .HasColumnType("datetime2");
            entity.Property(prop => prop.DataIndeferimento)
                    .IsRequired()
                    .HasColumnName("DataIndeferimento")
                    .HasColumnType("datetime2");
            entity.Property(prop => prop.DataExpirado)
                    .IsRequired()
                    .HasColumnName("DataExpirado")
                    .HasColumnType("datetime2");
            entity.HasOne(prop => prop.Evento)
                   .WithMany()
                   .HasForeignKey(x => x.IdEvento)
                   .IsRequired();
            entity.HasOne(prop => prop.Servidor)
                   .WithMany()
                   .HasForeignKey(x => x.IdServidor)
                   .IsRequired();
            entity.HasOne(prop => prop.Consignacao)
                   .WithOne()
                   .HasForeignKey<ConsignacaoProposta>(x => x.IdConsignacao)
                   .IsRequired(false);
            entity.HasOne(prop => prop.UsuarioCadastrante)
                   .WithMany()
                   .HasForeignKey(x => x.IdUsuarioCadastrante)
                   .IsRequired();
            entity.HasOne(prop => prop.UsuarioDeferimento)
                   .WithMany()
                   .HasForeignKey(x => x.IdUsuarioDeferimento);
        }
    }
}
