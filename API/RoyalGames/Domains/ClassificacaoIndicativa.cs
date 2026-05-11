using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class ClassificacaoIndicativa
{
    public int ClassificacaoID { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Produto> Produto { get; set; } = new List<Produto>();
}
