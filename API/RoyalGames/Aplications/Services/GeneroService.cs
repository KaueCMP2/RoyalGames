using Azure.Core;
using RoyalGames.Domains;
using RoyalGames.DTOs.GeneroDto;
using RoyalGames.Exceptions;
using RoyalGames.Interfaces;
using RoyalGames.Repositories;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace RoyalGames.Aplications.Services
{
    public class GeneroService
    {
        private readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;   
        }

        public List<LerGeneroDto> Listar()
        {
            List<Genero> generos = _repository.Listar();

            List<LerGeneroDto> generoDto = generos.Select(genero => new LerGeneroDto
            {
                GeneroId = genero.GeneroId,
                Nome = genero.Nome
            }).ToList();

        return generoDto;
        }


        public LerGeneroDto ObterPorId(int id)
        {
            Genero genero = _repository.ObterPorId(id);

            if(genero == null)
            {
                throw new DomainException("Gênero já existe!");
            }
            LerGeneroDto generoDto = new LerGeneroDto
            {
                GeneroId = genero.GeneroId,
                Nome = genero.Nome
            };

            return generoDto;
        }

        public static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatório.");
            }
        }

        public void Adicionar(CriarGeneroDto criarDto)
        {
            ValidarNome(criarDto.Nome);

            if (_repository.NomeExiste(criarDto.Nome))
            {
                throw new DomainException("Genero já existente.");
            }

            Genero genero = new Genero
            {
                Nome = criarDto.Nome
            };

            _repository.Adicionar(genero);
        }
        public void Atualizar(int id, CriarGeneroDto criardto)
        {
            ValidarNome(criardto.Nome);

            Genero generoBanco = _repository.ObterPorId(id);

            if( generoBanco == null)
            {
                throw new DomainException("Gênero não encontrado!");
            }

            if (_repository.NomeExiste(criardto.Nome))
            {
                throw new DomainException("Já existe um gênero com esse nome!");
            }

            generoBanco.Nome = criardto.Nome;
            return;
        }

        public void Remover(int id)
        {
            Genero generoBanco =_repository.ObterPorId(id);

            if( generoBanco == null)
            {
                throw new DomainException("Gênero não enocntrado!");
            }

            _repository.Remover(id);
        }
    }
}
