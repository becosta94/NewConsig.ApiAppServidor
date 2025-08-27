using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class ServidorMap : IEntityTypeConfiguration<Servidor>
    {
        public void Configure(EntityTypeBuilder<Servidor> entity)
        {
            entity.ToTable("Servidor");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.IdSecretaria)
                    .IsRequired()
                    .HasColumnName("IdSecretaria")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdVinculoEmpregaticio)
                    .IsRequired()
                    .HasColumnName("IdVinculoEmpregaticio")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.IdUsuario)
                    .IsRequired()
                    .HasColumnName("IdUsuario")
                    .HasColumnType("bigint");
            entity.Property(prop => prop.Matricula)
                    .IsRequired()
                    .HasColumnName("Matricula")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Cpf)
                    .IsRequired()
                    .HasColumnName("Cpf")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Email)
                    .HasColumnName("Email")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Telefone)
                    .HasColumnName("Telefone")
                    .HasColumnType("VARCHAR(30)");
            entity.Property(prop => prop.Rg)
                    .HasColumnName("Rg")
                    .HasColumnType("VARCHAR(30)");
            entity.Property(prop => prop.DataAdmissao)
                    .HasColumnName("DataAdmissao")
                    .HasColumnType("date")
                    .IsRequired(false);
            entity.Property(prop => prop.DataNascimento)
                    .HasColumnName("DataNascimento")
                    .HasColumnType("date")
                    .IsRequired(false);
            entity.Property(prop => prop.DataFimContrato)
                    .HasColumnName("DataFimContrato")
                    .HasColumnType("date")
                    .IsRequired(false);
            entity.HasOne(prop => prop.Secretaria)
                   .WithMany(prop => prop.Servidores)
                   .HasForeignKey(x => x.IdSecretaria)
                   .IsRequired();
            entity.HasOne(prop => prop.VinculoEmpregaticio)
                   .WithMany(prop => prop.Servidores)
                   .HasForeignKey(x => x.IdVinculoEmpregaticio)
                   .IsRequired();
            entity.HasOne(prop => prop.Usuario)
                   .WithMany(prop => prop.Servidores)
                   .HasForeignKey(x => x.IdUsuario)
                   .IsRequired();
        }
    }
}
