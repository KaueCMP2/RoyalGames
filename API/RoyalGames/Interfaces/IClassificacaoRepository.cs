using RoyalGames.Domains;

namespace RoyalGames.Interfaces
{
    public interface IClassificacaoRepository
    {
        public List<ClassificacaoIndicativa> Listar();
        public ClassificacaoIndicativa ObterClassificacaoPorId(int id);
    }
}
