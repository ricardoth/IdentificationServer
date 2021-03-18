using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class App
    {
        public App()
        {
            Menus = new HashSet<Menu>();
        }

        [Key]
        public int IdApp { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsActivo { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
