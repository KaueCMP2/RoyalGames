using RoyalGames.Domains;

namespace RoyalGames.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();
        Jogo ObterPorId(int id);
        bool NomeExiste(string nome, int? JogoIdAtual = null);
        byte[] ObterImagem(int id);
        void Adicionar(Jogo Jogo, List<int> generoIds, List<int> plataformaIds);
        void Atualizar(Jogo Jogo, List<int> generoIds, List<int> plataformaIds);
        void Remover(int id);
    }
}
