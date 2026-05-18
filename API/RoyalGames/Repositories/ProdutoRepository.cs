using Microsoft.EntityFrameworkCore;
using RoyalGames.Contexts;
using RoyalGames.Domains;
using RoyalGames.Interfaces;

namespace RoyalGames.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly RoyalGamesContext _context;
        public JogoRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<Jogo> Listar()
        {
            List<Jogo> jogos = _context.Jogo
                .Include(p => p.JogoPromocao)
                .Include(p => p.Log_AlteracaoJogo)
                .Include(p => p.Genero)
                .Include(p => p.Plataforma)
                .OrderBy(p => p.JogoId)
                .ToList();

            return jogos;
        }

        public Jogo ObterPorId(int id)
        {
            Jogo? jogo = _context.Jogo
                .Include(p => p.Genero)
                .FirstOrDefault(p => p.JogoId == id);

            return jogo;
        }

        public bool NomeExiste(string nome, int? JogoIdAtual = null)
        {
            var jogoBanco = _context.Jogo.AsQueryable();

            if(JogoIdAtual.HasValue)
                jogoBanco = jogoBanco.Where(p => p.JogoId != JogoIdAtual.Value);

            return jogoBanco.Any(p => p.Nome == nome);
        }

        public byte[] ObterImagem(int id)
        {
            var imagemJogo = _context.Jogo
                .Where(p => p.JogoId == id)
                .Select(p => p.Imagem)
                .FirstOrDefault();

            return imagemJogo;
        }

        public void Adicionar(Jogo jogo, List<int> generoIds)
        {
            // Busca e guarda em generos, todas as categorias cujo o id foi chamado.
            List<Genero> generos = _context.Genero
                .Where(g => generoIds.Contains(g.GeneroId))
                .ToList();

            jogo.Genero = generos;

            _context.Add(jogo);
            _context.SaveChanges();
        }

        public void Atualizar(Jogo jogo, List<int> generoIds)
        {
            Jogo? jogoBanco = _context.Jogo
                .Include(p => p.Genero)
                .FirstOrDefault(j => j.JogoId == j.JogoId);

            if (jogoBanco == null)
                return;

            jogoBanco.Nome = jogo.Nome;
            jogoBanco.Valor = jogo.Valor;
            jogoBanco.Descricao = jogo.Descricao; 

            if(jogo.Imagem != null)
                jogoBanco.Imagem = jogo.Imagem;

            if(jogo.StatusJogo)
                jogoBanco.StatusJogo = jogo.StatusJogo;

            // Busca e guarda em generos, todas as categorias cujo o id foi chamado.
            var generos = _context.Genero
                .Where(g => generoIds.Contains(g.GeneroId))
                .ToList();

            // Remover as com categorias atuais ligações atuais 
            jogoBanco.Genero.Clear();

            foreach(var genero in generos)
            {
                jogoBanco.Genero.Add(genero);
            }

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Jogo jogoRemovido = _context.Jogo.FirstOrDefault(j => j.JogoId == id);
            if (jogoRemovido == null)
                return;

            _context.Remove(jogoRemovido);
            _context.SaveChanges();
        }
    }
}
