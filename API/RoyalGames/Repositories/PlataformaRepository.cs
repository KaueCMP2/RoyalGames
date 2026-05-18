using RoyalGames.Contexts;
using RoyalGames.Domains;
using RoyalGames.Interfaces;

namespace RoyalGames.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
       private readonly RoyalGamesContext _context;

        public  PlataformaRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<Plataforma> Listar()
        {
            return _context.Plataforma.ToList();
        }

        // Busca uma categoria pelo ID.
        public Plataforma ObterPorId(int id)
        {   
            // Procura no banco a primeira categoria com o ID informado.
            Plataforma plataforma = _context.Plataforma.FirstOrDefault(p => p.PlataformaId == id);

            // Retorna a categoria encontrada ou null se não existir.
            return plataforma;
        }

        // Verifica se já existe uma categoria com o mesmo nome.
        // plataformaIdAtual é usado quando se está editando.
        public bool NomeExiste(string nome, int? PlataformaIdAtual = null)
        {
            // AsQueryable() => Consulta a tabela plataforma sem executar nada no banco.
            var consulta = _context.Plataforma.AsQueryable();

            // Se o ID atual for informado, signifca que a plataforma existente está sendo editada.
            // A própria plataforma será ignorada na verificação.

            if (PlataformaIdAtual.HasValue)
            {
                // Remove da busca a própria categoria
                // Evita duplicidade.
                consulta = consulta.Where(p => p.PlataformaId != PlataformaIdAtual.Value);
            }

           //Verificação de plataforma com o mesmo nome, caso encontre retorna true se não false
           return consulta.Any(p => p.Nome == nome);
        }

        // Adiciona uma nova plataforma no banco.
        void Adicionar(Plataforma plataforma)
        {
            _context.Plataforma.Add(plataforma);
            _context.SaveChanges();
        }

        void Atualizar(Plataforma plataforma)
        {
            // Busca uma pltaforma pelo ID no banco 
            Plataforma plataformaBanco = _context.Plataforma.FirstOrDefault(p => p.PlataformaId == plataforma.PlataformaId);

            // Se não encontrar nada retorna a saído do método.
            if (plataformaBanco == null)
            {
                return;
            }

            // Atualização do campo nome
            plataformaBanco.Nome = plataforma.Nome;
            _context.SaveChanges();
        }

        // Remove uma categoria pelo ID
        void Remover(int id)
        {
            // Busca uma pltaforma pelo ID no banco 
            Plataforma plataformaBanco = _context.Plataforma.FirstOrDefault(p => p.PlataformaId == id);

            // Se não encontrar nada retorna a saído do método.
            if (plataformaBanco == null)
            {
                return;
            }

            // Remoção da plataforma
            _context.Plataforma.Remove(plataformaBanco);
            _context.SaveChanges();
        }

        void IPlataformaRepository.Adicionar(Plataforma plataforma)
        {
            Adicionar(plataforma);
        }

        void IPlataformaRepository.Atualizar(Plataforma plataforma)
        {
            Atualizar(plataforma);
        }

        void IPlataformaRepository.Remover(int id)
        {
            Remover(id);
        }
    }
}
