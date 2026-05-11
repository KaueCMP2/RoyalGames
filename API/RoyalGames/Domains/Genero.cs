using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class Genero
{
    public int GeneroID { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Produto> Produto { get; set; } = new List<Produto>();
}
