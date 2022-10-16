using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.DTOs
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string CodigoCliente { get; set; }
        public string Empresa { get; set; }
        public string NombreCliente { get; set; }
        public string Cargo { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
    }
}
