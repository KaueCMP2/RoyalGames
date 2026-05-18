using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RoyalGames.Domains;
using RoyalGames.Exceptions;

namespace RoyalGames.Aplications.Authentication
{
    public class GeradorTokenJwt
    {
        private readonly IConfiguration _config;

        public GeradorTokenJwt(IConfiguration config)
        {
            _config = config;
        }

        public string GerarToken(Usuario usuario)
        {
            // Chave do Jwt
            var chave = _config["Jwt:Key"]!;

            // Quem gera o token
            var issuer = _config["Jwt:Issuer"]!;

            // Quem pediu para gerar o token
            var audience = _config["Jwt:Audience"]!;

            // Tempo de validade
            var expiraEmMinutos = int.Parse(_config["Jwt:ExpirationTime"]!);

            // Converte a chave em bytes
            var keyBytes = Encoding.UTF8.GetBytes(chave);

            if (keyBytes.Length < 32)
                throw new Exception("Jwt: key precisa ter no minimo 32 caracteres (256 bits");

            // Criar uma chave de seguraça usada para assinar token
            var securityKey = new SymmetricSecurityKey(keyBytes);

            // Definir o algoritimo de assinatura do token
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // As informações do usuarios que vão dentro do token
            // Informações que futuramente podem ser recuperadas na api, para saber quem esta logado
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,                                         // Quem gerou o token
                audience: audience,                                     // Quem pode usar o token
                claims: claims,                                         // Os dados do usuario
                expires: DateTime.Now.AddMinutes(expiraEmMinutos),      // Quando expira
                signingCredentials: credentials                         // Assinatura de segurança
                );

            // Converte o token para string, e envia para o cliente
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
