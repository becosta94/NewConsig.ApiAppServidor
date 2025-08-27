namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class Servidor : EntidadeBase
    {
        public long IdSecretaria { get; set; }
        public string Matricula { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Rg { get; set; }
        public long IdVinculoEmpregaticio { get; set; }
        public long IdUsuario { get; set; }
        public bool Ativo { get; set; }
        public DateOnly? DataAdmissao { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public DateOnly? DataFimContrato { get; set; }
        public virtual Secretaria Secretaria { get; set; }
        public virtual VinculoEmpregaticio VinculoEmpregaticio { get; set; }
        public virtual List<Consignacao>? Consignacoes { get; set; }
        public virtual List<EntradaMargem>? EntradasMargem { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
