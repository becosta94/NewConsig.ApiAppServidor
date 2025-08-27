namespace NewConsig.ApiAppServidor.Domain.Entities
{
    public class Secretaria : EntidadeBase
    {
        public string? IdFolha { get; set; }
        public string? NomeFolha { get; set; }
        public long IdGrupoSecretaria { get; set; }
        public virtual ICollection<Servidor> Servidores { get; set; }
    }
}
