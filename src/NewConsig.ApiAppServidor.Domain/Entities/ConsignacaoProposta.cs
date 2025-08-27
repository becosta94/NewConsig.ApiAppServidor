namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class ConsignacaoProposta : EntidadeBase
    {
        public long IdEvento { get; set; }
        public long IdServidor { get; set; }
        public long? IdConsignacao { get; set; }
        public long IdUsuarioCadastrante { get; set; }
        public long? IdUsuarioDeferimento { get; set; }
        public int Prazo { get; set; }
        public decimal ValorContratado { get; set; }
        public decimal ValorMensal { get; set; }
        public bool AceiteServidor { get; set; }
        public bool Deferido { get; set; }
        public bool Indeferido { get; set; }
        public bool Expirado { get; set; }
        public bool Carencia { get; set; }
        public string? NumeroContratoBanco { get; set; }
        public DateTime DataAceite { get; set; }
        public DateTime DataDeferimento { get; set; }
        public DateTime DataIndeferimento { get; set; }
        public DateTime DataCarencia { get; set; }
        public DateTime DataExpirado { get; set; }
        public Evento Evento { get; set; }
        public Servidor Servidor { get; set; }
        public Consignacao? Consignacao { get; set; }
        public Usuario UsuarioCadastrante { get; set; }
        public Usuario? UsuarioDeferimento { get; set; }
    }
}
