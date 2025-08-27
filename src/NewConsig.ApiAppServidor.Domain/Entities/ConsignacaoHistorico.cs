namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class ConsignacaoHistorico : EntidadeBase
    {
        public long IdConsignacao { get; set; }
        public DateTime DataPagamento { get; set; }
        public int NumeroParcelaPaga { get; set; }
        public decimal? ValorPago { get; set; }
        public long? IdProcessamentoArquivo { get; set; }
        public virtual Consignacao? Consignacao { get; set; }
    }
}
