using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Infrastructure.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("Usuario");
            entity.HasKey(e => e.Id);
            entity.Property(prop => prop.Id)
                    .ValueGeneratedOnAdd();
            entity.Property(prop => prop.Cpf)
                    .IsRequired()
                    .HasColumnName("Cpf")
                    .HasColumnType("VARCHAR(11)");
            entity.Property(prop => prop.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Email)
                    .IsRequired(false)
                    .HasColumnName("Email")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.Senha)
                    .IsRequired()
                    .HasColumnName("Senha")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.SenhaAnterior)
                    .IsRequired(false)
                    .HasColumnName("SenhaAnterior")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.TokenAlteracaoSenha)
                    .IsRequired(false)
                    .HasColumnName("TokenAlteracaoSenha")
                    .HasColumnType("VARCHAR(150)");
            entity.Property(prop => prop.ExpiracaoSenha)
                    .IsRequired()
                    .HasColumnName("ExpiracaoSenha")
                    .HasColumnType("datetime2");
            entity.Property(prop => prop.Bloqueado)
                    .HasColumnName("Bloqueado")
                    .HasColumnType("bit");
            entity.Property(prop => prop.PrimeiroAcesso)
                    .IsRequired()
                    .HasColumnName("PrimeiroAcesso")
                    .HasColumnType("bit");
            entity.HasIndex(prop => prop.Cpf)
                    .HasDatabaseName("IX_Cpf")
                    .IsUnique();
        }
    }
}
