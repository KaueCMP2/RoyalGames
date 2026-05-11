using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class Produto
{
    public int ProdutoID { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public string Descricao { get; set; } = null!;

    public byte[] Imagem { get; set; } = null!;

    public bool? StatusProduto { get; set; }

    public int UsuarioID { get; set; }

    public int ClassificacaoID { get; set; }

    public virtual ClassificacaoIndicativa Classificacao { get; set; } = null!;

    public virtual ICollection<Log_AlteracaoProduto> Log_AlteracaoProduto { get; set; } = new List<Log_AlteracaoProduto>();

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Genero> Genero { get; set; } = new List<Genero>();

    public virtual ICollection<Plataforma> Plataforma { get; set; } = new List<Plataforma>();
}
