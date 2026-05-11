using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class Log_AlteracaoProduto
{
    public int Log_AlteracaoProdutoID { get; set; }

    public DateTime DataAlteracao { get; set; }

    public string? NomeAnterior { get; set; }

    public decimal? PrecoAnterior { get; set; }

    public int? ProdutoID { get; set; }

    public virtual Produto? Produto { get; set; }
}
