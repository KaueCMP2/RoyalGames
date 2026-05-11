using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using RoyalGames.Aplications.Authentication;
using RoyalGames.Domains;
using RoyalGames.DTOs.AutenticacaoDto;
using RoyalGames.Exceptions;
using RoyalGames.Interfaces;

namespace RoyalGames.Aplications.Services
{
    public class AutenticacaoService
    {
        private readonly IUsuarioRepository _repository;
        private readonly GeradorTokenJwt _tokenJwt;

        public AutenticacaoService(IUsuarioRepository repository, GeradorTokenJwt tokenJwt)
        {
            _repository = repository;
            _tokenJwt = tokenJwt;
        }

        // Comparar hash senha
        private static bool VerificarSenha(string senhaDigitada, byte[] senhaBytes)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var hashDigitado = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senhaDigitada));

            return hashDigitado.SequenceEqual(senhaBytes);
        }

        public TokenDto Login(LoginDto loginDto)
        {
            Usuario usuario = _repository.ObterPorEmail(loginDto.Email);

            if (usuario == null) //Usuario
                throw new DomainException("E-mail ou senha invalidos");

            if (usuario.StatusUsuario == false)
                throw new DomainException("E-mail ou senha invalidos");

            if (!VerificarSenha(loginDto.Senha, usuario.Senha))
                throw new DomainException("E-mail ou senha invalidos");

            var token = _tokenJwt.GerarToken(usuario);

            // Retornamos somente o token do usuario, como esta na DTO
            TokenDto NovotokenDto = new TokenDto { Token = token };
            return NovotokenDto;
        }
    }
}
