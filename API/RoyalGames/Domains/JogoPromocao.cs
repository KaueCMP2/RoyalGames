using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class JogoPromocao
{
    public int PromocaoId { get; set; }

    public int JogoId { get; set; }

    public decimal? Valor { get; set; }

    public virtual Jogo Jogo { get; set; } = null!;

    public virtual Promocao Promocao { get; set; } = null!;
}
