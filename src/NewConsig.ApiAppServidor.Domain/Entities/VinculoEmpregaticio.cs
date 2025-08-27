namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class VinculoEmpregaticio : EntidadeBase
    {
        public string? IdFolha { get; set; }
        public string? NomeFolha { get; set; }
        public virtual ICollection<Servidor> Servidores { get; set; }
    }
}
