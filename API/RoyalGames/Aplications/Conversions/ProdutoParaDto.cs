using RoyalGames.Domains;
using RoyalGames.DTOs.ProdutoDto;

namespace RoyalGames.Aplications.Conversions
{
    public class ProdutoParaDto
    {
        public static LerProdutoDto ConverterParaDto(Produto produto)
        {
            return new LerProdutoDto
            {
                ProdutoID = produto.ProdutoID,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                StatusProduto = produto.StatusProduto,

                GeneroIds = produto.Genero.Select(categoria => categoria.GeneroID).ToList(),

                Generos = produto.Genero.Select(categoria => categoria.Nome).ToList(),

                UsuarioID = produto.UsuarioID,
                UsuarioNome = produto.Usuario?.Nome,
                UsuarioEmail = produto.Usuario?.Email
            };
        }
    }
}
