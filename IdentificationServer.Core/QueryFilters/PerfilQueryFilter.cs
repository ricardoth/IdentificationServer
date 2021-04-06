using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.QueryFilters
{
    public class PerfilQueryFilter
    {
        public int? IdPerfil { get; set; }
        public string Nombre { get; set; }
        public bool? EsActivo { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
