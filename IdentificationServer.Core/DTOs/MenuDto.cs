using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.DTOs
{
    public class MenuDto
    {
        public int IdMenu { get; set; }
        public int? IdApp { get; set; }
        public int? Padre { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string UrlFriend { get; set; }
        public bool EsActivo { get; set; }
        public bool EsPadre { get; set; }
        public bool TieneHijos { get; set; }
    }
}
