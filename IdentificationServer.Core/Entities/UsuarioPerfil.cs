using System;
using System.Collections.Generic;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class UsuarioPerfil : BaseEntity
    {
        //public int IdUsuarioPerfil { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public bool EsActivo { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
