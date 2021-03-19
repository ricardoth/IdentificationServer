using System;
using System.Collections.Generic;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class MenuPerfil
    {
        public int IdMenuPerfil { get; set; }
        public int IdMenu { get; set; }
        public int IdPerfil { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
    }
}
