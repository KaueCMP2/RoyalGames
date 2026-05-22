using RoyalGames.Domains;
using RoyalGames.DTOs.ClassificacaoDto;
using RoyalGames.Interfaces;

namespace RoyalGames.Aplications.Services
{
    public class ClassificacaoService
    {
        private readonly IClassificacaoRepository _repository;
        public ClassificacaoService(IClassificacaoRepository repository)
        {
            _repository = repository;
        }

        public List<LerClassificacaoDto> Listar()
        {
            List<ClassificacaoIndicativa> classificacoes = _repository.Listar();
            List<LerClassificacaoDto> classificacaoDto = classificacoes.Select(classificacao => new LerClassificacaoDto
            {
                ClassificacaoId = classificacao.ClassificacaoId,
                ClassificacaoNome = classificacao.ClassificacaoNome
            }).ToList();

            return classificacaoDto;
        }

        public LerClassificacaoDto ObterClassificacaoPorId(int id)
        {
            ClassificacaoIndicativa classificacao = _repository.ObterClassificacaoPorId(id);
            return new LerClassificacaoDto
            {
                ClassificacaoId = classificacao.ClassificacaoId,
                ClassificacaoNome = classificacao.ClassificacaoNome
            };
        }
    }
}
