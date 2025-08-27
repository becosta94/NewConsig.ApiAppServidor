namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class Evento : EntidadeBase
    {
        public long IdConsignataria { get; set; }
        public long IdServico { get; set; }
        public string? Nome { get; set; }
        public string? IdFolha { get; set; }
        public bool Ativo { get; set; }
        public Servico Servico { get; set; }
        public Consignataria Consignataria { get; set; }
        public ICollection<Consignacao> Consignacoes { get; set; }
        public bool FlagSobreporPrazoServico { get; set; }
        public int PrazoSobreporServico { get; set; }
    }
}
