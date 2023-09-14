using System;
using System.Collections.Generic;

namespace TPIIntegrador.Dominio.Entidades
{
    public partial class Rol
    {
        public Rol()
        {
            RolClaims = new HashSet<RolClaim>();
            Users = new HashSet<Usuario>();
        }

        public string Id { get; set; } = null!;
        public string? NombreRol { get; set; }
        public string? NormalizedName { get; set; }

        public virtual ICollection<RolClaim> RolClaims { get; set; }

        public virtual ICollection<Usuario> Users { get; set; }
    }
}
