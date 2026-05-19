using RoyalGames.Domains;
using RoyalGames.DTOs.JogoDto;

namespace RoyalGames.Aplications.Conversions
{
    public class JogoParaDto
    {
        public static LerJogoDto ConverterParaDto(Jogo jogo)
        {
            return new LerJogoDto
            {
                JogoId = jogo.JogoId,
                Nome = jogo.Nome,
                Valor = jogo.Valor,
                Descricao = jogo.Descricao,
                StatusJogo = jogo.StatusJogo,
                ImgUrl = $"jogo/{jogo.JogoId}/imagem",

                GeneroIds = jogo.Genero.Select(categoria => categoria.GeneroId).ToList(),
                Generos = jogo.Genero.Select(categoria => categoria.Nome).ToList(),
            };
        }
    }
}
