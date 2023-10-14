﻿using System;

namespace IdentificationServer.Core.DTOs
{
    public class UsuarioDto
    {
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
        public bool EsActivo { get; set; }
    }
}
