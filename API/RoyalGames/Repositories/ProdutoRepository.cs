using Microsoft.EntityFrameworkCore;
using RoyalGames.Contexts;
using RoyalGames.Domains;
using RoyalGames.Interfaces;

namespace RoyalGames.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly RoyalGamesContext _context;
        public ProdutoRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<Produto> Listar()
        {
            List<Produto> produtos = _context.Produto
                .Include(p => p.Genero)
                .Include(p => p.Usuario)
                .ToList();

            return produtos;
        }

        public Produto ObterPorId(int id)
        {
            Produto? produto = _context.Produto
                .Include(p => p.Genero)
                .Include(p => p.Usuario)
                .FirstOrDefault(p => p.ProdutoID == id);

            return produto;
        }

        public bool NomeExiste(string nome, int? produtoIdAtual = null)
        {
            var produtoBanco = _context.Produto.AsQueryable();

            if(produtoIdAtual.HasValue)
                produtoBanco = produtoBanco.Where(p => p.ProdutoID != produtoIdAtual.Value);

            return produtoBanco.Any(p => p.Nome == nome);
        }

        public byte[] ObterImagem(int id)
        {
            var imagemProduto = _context.Produto
                .Where(p => p.ProdutoID == id)
                .Select(p => p.Imagem)
                .FirstOrDefault();

            return imagemProduto;
        }

        public void Adicionar(Produto produto, List<int> generoIds)
        {
            // Busca e guarda em generos, todas as categorias cujo o id foi chamado.
            List<Genero> generos = _context.Genero
                .Where(g => generoIds.Contains(g.GeneroID))
                .ToList();

            produto.Genero = generos;

            _context.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto, List<int> generoIds)
        {
            Produto? produtoBanco = _context.Produto
                .Include(p => p.Genero)
                .FirstOrDefault(p => p.ProdutoID == produto.ProdutoID);

            if (produtoBanco == null)
                return;

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Preco = produto.Preco;
            produtoBanco.Descricao = produto.Descricao; 

            if(produto.Imagem != null)
                produtoBanco.Imagem = produto.Imagem;

            if(produto.StatusProduto.HasValue)
                produtoBanco.StatusProduto = produto.StatusProduto.Value;

            // Busca e guarda em generos, todas as categorias cujo o id foi chamado.
            var generos = _context.Genero
                .Where(g => generoIds.Contains(g.GeneroID))
                .ToList();

            // Remover as com categorias atuais ligações atuais 
            produtoBanco.Genero.Clear();

            foreach(var genero in generos)
            {
                produtoBanco.Genero.Add(genero);
            }

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Produto produtoRemovido = _context.Produto.FirstOrDefault(p => p.ProdutoID == id);
            if (produtoRemovido == null)
                return;

            _context.Remove(produtoRemovido);
            _context.SaveChanges();
        }
    }
}
