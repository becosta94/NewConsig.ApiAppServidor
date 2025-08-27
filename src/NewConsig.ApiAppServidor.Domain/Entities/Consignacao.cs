namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class Consignacao : EntidadeBase
    {
        public long IdServidor { get; set; }
        public long IdEvento { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public DateTime DataInicioDesconto { get; set; }
        public int Prazo { get; set; }
        public decimal ValorMensal { get; set; }
        public long? IdProcessamentoArquivo { get; set; }
        public string? NumeroContratoBanco { get; set; }
        public bool Suspenso { get; set; }
        public Evento Evento { get; set; }
        public Servidor Servidor { get; set; }
        public List<ConsignacaoHistorico> ConsignacaoHistorico { get; set; }
        public Consignacao() { }
    }
}
