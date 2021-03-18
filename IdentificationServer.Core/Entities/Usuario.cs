using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            MenuUsuarios = new HashSet<MenuUsuario>();
            UsuarioPerfils = new HashSet<UsuarioPerfil>();
        }

        [Key]
        public int IdUsuario { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool EsActivo { get; set; }

        public virtual ICollection<MenuUsuario> MenuUsuarios { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
