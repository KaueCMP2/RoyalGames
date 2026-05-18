using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class Jogo
{
    public int JogoId { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public byte[] Imagem { get; set; } = null!;

    public bool StatusJogo { get; set; }

    public int ClassificacaoId { get; set; }

    public virtual ClassificacaoIndicativa Classificacao { get; set; } = null!;

    public virtual ICollection<JogoPromocao> JogoPromocao { get; set; } = new List<JogoPromocao>();

    public virtual ICollection<Log_AlteracaoJogo> Log_AlteracaoJogo { get; set; } = new List<Log_AlteracaoJogo>();

    public virtual ICollection<Genero> Genero { get; set; } = new List<Genero>();

    public virtual ICollection<Plataforma> Plataforma { get; set; } = new List<Plataforma>();
}
