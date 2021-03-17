using System;
using System.Collections.Generic;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class MenuUsuario
    {
        public int IdMenuUsuario { get; set; }
        public int IdMenu { get; set; }
        public int IdUsuario { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
