namespace RoyalGames.DTOs.JogoDto
{
    public class AtualizarJogoDto
    {
        public string Nome { get; set; } = null!;

        public decimal Valor { get; set; }

        public string Descricao { get; set; } = null!;

        public IFormFile Imagem { get; set; } = null!; // A imagem vem via multipart/form-data, ideal para upload de arquivo

        public List<int> GeneroIds { get; set; } = new();
        public int ClassificacaoIndicativaId { get; set; } = new();
        public List<int> PlataformaIds { get; set; } = new();
    }
}
