using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class Plataforma
{
    public int PlataformaId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Jogo> Jogo { get; set; } = new List<Jogo>();
}
