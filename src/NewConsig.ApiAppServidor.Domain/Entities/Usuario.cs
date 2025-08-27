using System.ComponentModel.DataAnnotations.Schema;

namespace NewConsig.ApiAppServidor.Domain.Entities;

public class Usuario : EntidadeBase
{
    public string? Cpf { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? SenhaAnterior { get; set; }
    public bool? Bloqueado { get; set; }
    public bool PrimeiroAcesso { get; set; }
    public string? TokenAlteracaoSenha { get; set; }
    [NotMapped]
    public string Token { get; set; }
    public DateTime ExpiracaoSenha { get; set; }
    public ICollection<Servidor>? Servidores { get; set; }
}
