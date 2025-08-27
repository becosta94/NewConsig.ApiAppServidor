using NewConsig.ApiAppServidor.Domain.Entities;

namespace NewConsig.ApiAppServidor.Application.Services.Interfaces
{
    public interface ITokenServico
    {
        public Usuario GerarToken(Usuario usuario);
        public string GerarTokenTrocaSenha();
    }
}
