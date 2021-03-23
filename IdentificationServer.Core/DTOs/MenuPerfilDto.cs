using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.DTOs
{
    public class MenuPerfilDto
    {
        public int IdMenuPerfil { get; set; }
        public int IdMenu { get; set; }
        public int IdPerfil { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
