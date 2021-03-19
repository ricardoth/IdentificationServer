using System;
using System.Collections.Generic;
using System.Text;

namespace IdentificationServer.Core.DTOs
{
    public class PerfilDto
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public bool EsActivo { get; set; }
    }
}
