using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewConsig.ApiAppServidor.Application.Services.Interfaces;
using NewConsig.ApiAppServidor.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NewConsig.ApiAppServidor.Application.Services
{
    public class TokenServico : ITokenServico
    {
        private IConfiguration _configuracoes;
        public TokenServico(IConfiguration configuracoes)
        {
            _configuracoes = configuracoes;
        }
        public Usuario GerarToken(Usuario usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracoes.GetSection("SecretJwt").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(100);
            var idSessao = Guid.NewGuid().ToString();
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim("session_id", idSessao),
                };
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               expires: expiration,
               claims: claims,
               signingCredentials: creds);

            usuario.Token =  new JwtSecurityTokenHandler().WriteToken(token);
            return usuario;
        }

        public string GerarTokenTrocaSenha()
        {
            byte[] randomNumber = new byte[4]; // 4 bytes para um inteiro de 32 bits
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomNumber);
            }

            int number = BitConverter.ToInt32(randomNumber, 0);
            number = Math.Abs(number % (int)Math.Pow(10, 6));
            long horarioEmInteiro = DateTime.Now.AddDays(1).Ticks;
            return string.Concat(number.ToString("D" + 6), "-", horarioEmInteiro);
        }
    }
}
