using RoyalGames.Contexts;
using RoyalGames.Domains;
using RoyalGames.Interfaces;

namespace RoyalGames.Repositories
{
    public class ClassificacaoRepository : IClassificacaoRepository
    {
        private readonly RoyalGamesContext _context;
        public ClassificacaoRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<ClassificacaoIndicativa> Listar()
        {
            return _context.ClassificacaoIndicativa.OrderBy(c => c.ClassificacaoId).ToList();
        }

        public ClassificacaoIndicativa ObterClassificacaoPorId(int id)
        {
            return _context.ClassificacaoIndicativa.Find(id);
        }
    }
}
