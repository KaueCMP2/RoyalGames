namespace RoyalGames.DTOs.UsuarioDto
{
    public class LerUsuarioDto
    {
        public int UsuarioID { get; set; }

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool? StatusUsuario { get; set; } = null;
    }
}
