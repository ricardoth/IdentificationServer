﻿using System;
using System.Collections.Generic;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class Menu : BaseEntity
    {
        public Menu()
        {
            MenuPerfils = new HashSet<MenuPerfil>();
        }

        public int? IdApp { get; set; }
        public int? Padre { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string UrlFriend { get; set; }
        public bool EsActivo { get; set; }
        public bool EsPadre { get; set; }
        public bool TieneHijos { get; set; }

        public virtual App IdAppNavigation { get; set; }
        public virtual ICollection<MenuPerfil> MenuPerfils { get; set; }
    }
}
