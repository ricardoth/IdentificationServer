using System;
using System.Collections.Generic;
using System.Text;

namespace IdentificationServer.Core.DTOs
{
    public class UsuarioDto
    {
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool EsActivo { get; set; }
    }
}
