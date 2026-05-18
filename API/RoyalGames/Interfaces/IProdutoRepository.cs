using RoyalGames.Domains;

namespace RoyalGames.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();
        Jogo ObterPorId(int id);
        bool NomeExiste(string nome, int? JogoIdAtual = null);
        byte[] ObterImagem(int id);
        void Adicionar(Jogo Jogo, List<int> generoIds);
        void Atualizar(Jogo Jogo, List<int> generoIds);
        void Remover(int id);
    }
}
