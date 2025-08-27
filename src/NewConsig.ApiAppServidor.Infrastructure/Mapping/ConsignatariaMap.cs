using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class ConsignatariaMap : IEntityTypeConfiguration<Consignataria>
    {
        public void Configure(EntityTypeBuilder<Consignataria> entity)
        {
            entity.ToTable("Consignataria");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Codigo)
                    .IsRequired()
                    .HasColumnName("Codigo")
                    .HasColumnType("int");
            entity.Property(prop => prop.Sigla)
                    .IsRequired()
                    .HasColumnName("Sigla")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Ativa)
                    .IsRequired()
                    .HasColumnName("Ativa")
                    .HasColumnType("bit");
            entity.Property(prop => prop.Suspensa)
                    .IsRequired()
                    .HasColumnName("Suspensa")
                    .HasColumnType("bit");
            entity.Property(prop => prop.Cnpj)
                    .IsRequired()
                    .HasColumnName("Cnpj")
                    .HasColumnType("VARCHAR(14)");
            entity.Property(prop => prop.Email)
                    .IsRequired(false)
                    .HasColumnName("Email")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.ListaIps)
                    .IsRequired(false)
                    .HasColumnName("ListaIps")
                    .HasColumnType("VARCHAR(300)");
        }
    }
}
