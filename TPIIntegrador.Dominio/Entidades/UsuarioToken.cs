using System;
using System.Collections.Generic;

namespace TPIIntegrador.Dominio.Entidades
{
    public partial class UsuarioToken
    {
        public string UserId { get; set; } = null!;
        public string LoginProvider { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Value { get; set; }

        public virtual Usuario User { get; set; } = null!;
    }
}
