namespace RoyalGames.DTOs.JogoDto
{
    public class LerJogoDto
    {

        public int JogoId { get; set; }

        public string Nome { get; set; } = null!;
        public decimal Valor { get; set; }

        public string Descricao { get; set; } = null!;

        public bool? StatusJogo { get; set; }

        public string ImgUrl { get; set; }
        // categorias
        public List<int> GeneroIds { get; set; } = new();
        public List<string> Generos { get; set; } = new();
        public int ClassificacaoIndicativaId { get; set; }
        public List<int> PlataformaIds { get; set; }
    }
}
