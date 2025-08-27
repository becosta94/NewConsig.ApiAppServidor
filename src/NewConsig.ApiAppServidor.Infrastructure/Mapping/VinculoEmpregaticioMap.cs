using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class VinculoEmpregaticioMap : IEntityTypeConfiguration<VinculoEmpregaticio>
    {
        public void Configure(EntityTypeBuilder<VinculoEmpregaticio> entity)
        {
            entity.ToTable("VinculoEmpregaticio");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.IdFolha)
                    .IsRequired()
                    .HasColumnName("IdFolha")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.NomeFolha)
                    .IsRequired()
                    .HasColumnName("NomeFolha")
                    .HasColumnType("VARCHAR(150)");
        }
    }
}
