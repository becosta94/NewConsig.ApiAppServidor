using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class SecretariaMap : IEntityTypeConfiguration<Secretaria>
    {
        public void Configure(EntityTypeBuilder<Secretaria> entity)
        {
            entity.ToTable("Secretaria");
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
            entity.Property(prop => prop.IdGrupoSecretaria)
                    .HasColumnName("IdGrupo")
                    .HasColumnType("bigint");
        }
    }
}
