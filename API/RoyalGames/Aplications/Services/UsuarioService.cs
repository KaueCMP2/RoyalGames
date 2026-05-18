using RoyalGames.Domains;
using RoyalGames.DTOs.UsuarioDto;
using RoyalGames.Exceptions;
using RoyalGames.Interfaces;
using RoyalGames.Repositories;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace RoyalGames.Aplications.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        // LerUsuario
        public LerUsuarioDto LerDto(Usuario usuario)
        {
            LerUsuarioDto lerUsuario = new LerUsuarioDto
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                Email = usuario.Email,
                StatusUsuario = usuario.StatusUsuario
            };

            return lerUsuario;
        }

        // Listar varios usuario
        public List<LerUsuarioDto> Listar()
        {
            List<Usuario> usuarios = _repository.Listar();
            List<LerUsuarioDto> usuarioDtos = usuarios.Select(usuarioBanco => LerDto(usuarioBanco))
                .ToList();

            return usuarioDtos;
        }

        // Validar email
        private static void ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                throw new Exception("Email invalido");
        }

        // Validar e converter senha
        private static byte[] HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new Exception("Senha invalida!");

            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        // Buscar usuario por id
        public LerUsuarioDto ObterPorId(int id)
        {
            Usuario? usuario = _repository.ObterPorId(id);

            if (usuario == null)
                throw new DomainException("Usuario não encontrado");

            return LerDto(usuario);
        }

        // Buscar usuario por email
        public LerUsuarioDto ObterPorEmail(string email)
        {
            Usuario? usuario = _repository.ObterPorEmail(email);

            if (usuario == null)
                throw new DomainException("Usuario não encontrado");

            return LerDto(usuario);
        }

        // Adicionar usuario
        public LerUsuarioDto Adicionar(CriarUsuarioDto usuarioDto)
        {
            ValidarEmail(usuarioDto.Email);

            if (_repository.EmailExiste(usuarioDto.Email))
                throw new DomainException("Email já está em uso");

            Usuario usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = HashSenha(usuarioDto.Senha),
                StatusUsuario = true
            };

            _repository.Adicionar(usuario);
            return LerDto(usuario);
        }

        // Atualizar usuario
        public LerUsuarioDto Atualizar(int id, CriarUsuarioDto usuarioDto)
        {

            Usuario usuarioBanco = _repository.ObterPorId(id);

            if (usuarioBanco == null)
                throw new DomainException("Usuário não encontrado.");

            ValidarEmail(usuarioDto.Email);

            Usuario usuarioComMesmoEmail = _repository.ObterPorEmail(usuarioDto.Email);

            if (usuarioComMesmoEmail != null && usuarioComMesmoEmail.UsuarioId != id)
                throw new DomainException("Já existe um usuário com este e-mail.");

            usuarioBanco.Nome = usuarioDto.Nome;
            usuarioBanco.Email = usuarioDto.Email;
            usuarioBanco.Senha = HashSenha(usuarioDto.Senha);

            _repository.Atualizar(usuarioBanco);

            return LerDto(usuarioBanco);
        }

        // Remover Usuario
        public void Remover(int id)
        {
            Usuario usuario = _repository.ObterPorId(id);

            if (usuario == null)
            {
                throw new DomainException("Usuário não encontrado.");
            }

            _repository.Remover(id);
        }
    }
}
