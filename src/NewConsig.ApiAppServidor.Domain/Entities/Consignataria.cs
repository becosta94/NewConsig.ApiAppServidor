namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class Consignataria : EntidadeBase
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Sigla { get; set; }
        public string? Cnpj { get; set; }
        public string? Email { get; set; }
        public bool Ativa { get; set; }
        public bool Suspensa { get; set; }
        public string ListaIps { get; set; }
        public ICollection<Evento>? Eventos { get; set; }
    }
}
