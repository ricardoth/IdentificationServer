using IdentificationServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IMenuPerfilRepository
    {
        Task<IEnumerable<MenuPerfil>> GetMenuPerfils();
        Task<MenuPerfil> GetMenuPerfil(int id);
        Task<MenuPerfil> Agregar(MenuPerfil perfil);
        Task<bool> Actualizar(MenuPerfil perfil);
        Task<bool> Eliminar(int id);
    }
}
