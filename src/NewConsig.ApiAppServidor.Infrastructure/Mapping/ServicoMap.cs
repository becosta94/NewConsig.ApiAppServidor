using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> entity)
        {
            entity.ToTable("Servico");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Ativo)
                    .IsRequired()
                    .HasColumnName("Ativo")
                    .HasColumnType("bit");
        }
    }
}
