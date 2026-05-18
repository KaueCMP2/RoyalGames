using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class Log_AlteracaoJogo
{
    public int Log_AlteracaoJogoId { get; set; }

    public string NomeAnterior { get; set; } = null!;

    public decimal ValorAnterior { get; set; }

    public DateTime DataAlteracao { get; set; }

    public int JogoId { get; set; }

    public virtual Jogo Jogo { get; set; } = null!;
}
