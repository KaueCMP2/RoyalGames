using RoyalGames.Domains;

namespace RoyalGames.Interfaces
{
    public interface IGeneroRepository
    {
        List<Genero> Listar();
        Genero ObterPorId(int id);
        bool NomeExiste(string nome, int? GeneroIdAtual = null);
        void Adicionar(Genero genero);
        void Atualizar(Genero genero);
        void Remover(int id);
    }
}
