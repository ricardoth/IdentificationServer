using System;
using System.Collections.Generic;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            UsuarioPerfils = new HashSet<UsuarioPerfil>();
        }

        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool EsActivo { get; set; }

        public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
