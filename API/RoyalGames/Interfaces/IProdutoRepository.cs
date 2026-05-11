using RoyalGames.Domains;

namespace RoyalGames.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto ObterPorId(int id);
        bool NomeExiste(string nome, int? produtoIdAtual = null);
        byte[] ObterImagem(int id);
        void Adicionar(Produto produto, List<int> generoIds);
        void Atualizar(Produto produto, List<int> generoIds);
        void Remover(int id);
    }
}
