using System;

namespace IdentificationServer.Core.Entities
{
    public class Cliente : BaseEntity
    {
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
        public int UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
