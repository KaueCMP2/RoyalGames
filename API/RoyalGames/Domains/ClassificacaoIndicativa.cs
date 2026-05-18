using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class ClassificacaoIndicativa
{
    public int ClassificacaoId { get; set; }

    public string ClassificacaoNome { get; set; } = null!;

    public virtual ICollection<Jogo> Jogo { get; set; } = new List<Jogo>();
}
