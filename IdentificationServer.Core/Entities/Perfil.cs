using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class Perfil
    {
        public Perfil()
        {
            UsuarioPerfils = new HashSet<UsuarioPerfil>();
        }

        [Key]
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public bool EsActivo { get; set; }

        public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
