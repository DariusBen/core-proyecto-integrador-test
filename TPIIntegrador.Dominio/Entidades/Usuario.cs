using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPIIntegrador.Dominio.Entidades
{
    public class Usuario : IdentityUser
    {
        public Usuario()
        {
            Subasta = new HashSet<Subasta>();
        }

        public virtual IEnumerable<Subasta> Subasta { get; set; }
    }
}
