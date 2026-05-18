using RoyalGames.Contexts;
using RoyalGames.Domains;
using RoyalGames.Interfaces;

namespace RoyalGames.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly RoyalGamesContext _context;

        public GeneroRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<Genero> Listar()
        {
            return _context.Genero.OrderBy(g => g.GeneroId).ToList();
        }

        // Busca uma genero pelo ID.
        public Genero ObterPorId(int id)
        {
            // Procura no banco o primeiro genero com o ID informado.
            Genero genero  = _context.Genero.FirstOrDefault(g => g.GeneroId == id);

            // Retorna o genero encontrada ou null se não existir.
            return genero;
        }

        // Verifica se já existe um genero com o mesmo nome.
        // generoIdAtual é usado quando se está editando.
        public bool NomeExiste(string nome, int? GeneroIdAtual = null)
        {
            // AsQueryable() => Consulta a tabela plataforma sem executar nada no banco.
            var consulta = _context.Genero.AsQueryable();

            // Se o ID atual for informado, signifca que o genero existente está sendo editada.
            // O próprio genero será ignorada na verificação.

            if (GeneroIdAtual.HasValue)
            {
                // Remove da busca o próprio genero
                // Evita duplicidade.
                consulta = consulta.Where(g => g.GeneroId != GeneroIdAtual.Value);
            }

            //Verificação de genero com o mesmo nome, caso encontre retorna true se não false
            return consulta.Any(g => g.Nome == nome);
        }

        // Adiciona um novo genero no banco.
        public void Adicionar(Genero genero)
        {
            _context.Genero.Add(genero);
            _context.SaveChanges();
        }

        public void Atualizar(Genero genero)
        {
            // Busca um genero pelo ID no banco 
            Genero generoBanco = _context.Genero.FirstOrDefault(g => g.GeneroId == genero.GeneroId);

            // Se não encontrar nada retorna a saído do método.
            if (generoBanco == null)
            {
                return;
            }

            // Atualização do campo nome
            generoBanco.Nome = genero.Nome;
            _context.SaveChanges();
        }

        // Remove um genero pelo ID
        public void Remover(int id)
        {
            // Busca um genero pelo ID no banco 
            Genero generoBanco = _context.Genero.FirstOrDefault(g => g.GeneroId == id);

            // Se não encontrar nada retorna a saído do método.
            if (generoBanco == null)
            {
                return;
            }

            // Remoção do genero
            _context.Genero.Remove(generoBanco);
            _context.SaveChanges();
        }
    }
}
