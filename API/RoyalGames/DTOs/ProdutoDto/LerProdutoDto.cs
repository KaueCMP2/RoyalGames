namespace RoyalGames.DTOs.ProdutoDto
{
    public class LerProdutoDto
    {

        public int ProdutoID { get; set; }

        public string Nome { get; set; } = null!;

        public decimal Preco { get; set; }

        public string Descricao { get; set; } = null!;

        public bool? StatusProduto { get; set; }

        // categorias
        public List<int> GeneroIds { get; set; } = new();
        public List<string> Generos { get; set; } = new();

        // usuario que cadastrou
        public int? UsuarioID { get; set; }
        public string? UsuarioNome { get; set; }
        public string? UsuarioEmail { get; set; }
    }
}
