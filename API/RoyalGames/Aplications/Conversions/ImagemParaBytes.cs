namespace RoyalGames.Aplications.Conversions
{
    public class ImagemParaBytes
    {
        public static byte[] ConverterImagem(IFormFile Imagem)
        {
            using var ms = new MemoryStream();
            Imagem.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
