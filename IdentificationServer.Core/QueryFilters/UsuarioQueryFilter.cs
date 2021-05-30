using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.QueryFilters
{
    public class UsuarioQueryFilter
    {
        public int? Rut { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public bool? EsActivo { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
