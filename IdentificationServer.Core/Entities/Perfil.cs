﻿using System;
using System.Collections.Generic;

#nullable disable

namespace IdentificationServer.Core.Entities
{
    public partial class Perfil
    {
        public Perfil()
        {
            MenuPerfils = new HashSet<MenuPerfil>();
            UsuarioPerfils = new HashSet<UsuarioPerfil>();
        }

        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public bool EsActivo { get; set; }

        public virtual ICollection<MenuPerfil> MenuPerfils { get; set; }
        public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
