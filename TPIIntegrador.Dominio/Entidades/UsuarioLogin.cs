using System;
using System.Collections.Generic;

namespace TPIIntegrador.Dominio.Entidades
{
    public partial class UsuarioLogin
    {
        public string LoginProvider { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;
        public string? ProviderDisplayName { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Usuario User { get; set; } = null!;
    }
}
