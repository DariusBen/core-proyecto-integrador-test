using System;
using System.Collections.Generic;

namespace TPIIntegrador.Dominio.Entidades
{
    public partial class RolClaim
    {
        public int Id { get; set; }
        public string RoleId { get; set; } = null!;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }

        public virtual Rol Role { get; set; } = null!;
    }
}
