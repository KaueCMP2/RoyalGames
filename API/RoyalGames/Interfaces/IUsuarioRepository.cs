using RoyalGames.Domains;

namespace RoyalGames.Interfaces
{
    public interface IUsuarioRepository
    {
        // METODOS OBRIGATÓRIOS
        List<Usuario> Listar();

        Usuario? ObterPorId(int id);

        Usuario? ObterPorEmail(string email);
        
        bool EmailExiste(string email);

        void Adicionar(Usuario usuario);

        void Atualizar(Usuario usuario);

        void Remover(int id);
    }
}