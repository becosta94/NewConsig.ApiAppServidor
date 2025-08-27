namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class EntradaMargem : EntidadeBase
    {
        public long IdServidor { get; set; }
        public long IdServico { get; set; }
        public decimal Valor { get; set; }
        public long? IdProcessamentoArquivo { get; set; }
        public long? IdConsignacao { get; set; }
        public long? IdReservaMargem { get; set; }
        public Servidor Servidor { get; set; }
        public Servico Servico { get; set; }
        public Consignacao? Consignacao { get; set; }

        public EntradaMargem(long idServidor, long idServico, decimal valor, long reservaMargem)
        {
            IdServidor = idServidor;
            IdServico = idServico;
            Valor = valor;
            IdReservaMargem = reservaMargem;
        }

        public EntradaMargem()
        {
        }
    }
}
