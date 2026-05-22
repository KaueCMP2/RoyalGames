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
                ClassificacaoIndicativaId = jogo.ClassificacaoId,
                ImgUrl = $"jogo/{jogo.JogoId}/imagem",

                ClassificacaoIndicativa = jogo.Classificacao.ClassificacaoNome,

                GeneroIds = jogo.Genero.Select(categoria => categoria.GeneroId).ToList(),
                Generos = jogo.Genero.Select(categoria => categoria.Nome).ToList(),

                PlataformaIds = jogo.Plataforma.Select(plataforma => plataforma.PlataformaId).ToList(),
                Plataformas = jogo.Plataforma.Select(plataforma => plataforma.Nome).ToList(),
            };
        }
    }
}
