namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class Servico : EntidadeBase
    {
        public string? Nome { get; set; }
        public double FatorCalculo { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Evento> Eventos { get; set; }
    }
}
