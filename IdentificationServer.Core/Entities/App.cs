using System.Collections.Generic;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class App : BaseEntity
    {
        public App()
        {
            Menus = new HashSet<Menu>();
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlSitio { get; set; }
        public string UrlCambioContrasena { get; set; }
        public bool EsActivo { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
