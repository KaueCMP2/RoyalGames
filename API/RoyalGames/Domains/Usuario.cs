using System;
using System.Collections.Generic;

namespace RoyalGames.Domains;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[]? Senha { get; set; }

    public bool StatusUsuario { get; set; }
}
