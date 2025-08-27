using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> entity)
        {
            entity.ToTable("Evento");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.IdConsignataria)
                    .IsRequired()
                    .HasColumnName("IdConsignataria")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdServico)
                    .IsRequired()
                    .HasColumnName("IdServico")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Ativo)
                    .IsRequired()
                    .HasColumnName("Ativo")
                    .HasColumnType("bit");
            entity.Property(prop => prop.IdFolha)
                    .IsRequired()
                    .HasColumnName("IdFolha")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.FlagSobreporPrazoServico)
                    .IsRequired()
                    .HasColumnName("FlagSobreporPrazoServico")
                    .HasColumnType("bit")
                    .HasDefaultValue(false);
            entity.Property(prop => prop.PrazoSobreporServico)
                    .IsRequired()
                    .HasColumnName("PrazoSobreporServico")
                    .HasColumnType("int")
                    .HasDefaultValue(0);
            entity.HasOne(prop => prop.Servico)
                   .WithMany(prop => prop.Eventos)
                   .HasForeignKey(x => x.IdServico)
                   .IsRequired();
            entity.HasOne(prop => prop.Consignataria)
                   .WithMany(prop => prop.Eventos)
                   .HasForeignKey(x => x.IdConsignataria)
                   .IsRequired();
        }
    }
}
