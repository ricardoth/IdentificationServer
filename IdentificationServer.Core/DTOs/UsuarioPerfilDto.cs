using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.DTOs
{
    public class UsuarioPerfilDto
    {
        public int IdUsuarioPerfil { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public bool EsActivo { get; set; }
    }
}
