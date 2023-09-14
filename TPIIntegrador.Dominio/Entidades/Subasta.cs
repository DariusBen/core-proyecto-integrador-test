using System;
using System.Collections.Generic;

namespace TPIIntegrador.Dominio.Entidades
{
    public partial class Subasta : Entidad
    {
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Origen { get; set; } = null!;
        public string Destino { get; set; } = null!;
        public bool UsaPagoEnEfectivo { get; set; }
        public string IdUsuario { get; set; } = null!;

        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
