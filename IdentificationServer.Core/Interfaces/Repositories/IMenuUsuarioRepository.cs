using IdentificationServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IMenuUsuarioRepository
    {
        Task<IEnumerable<Menu>> GetMenuUsuario(int rut, int idApp);
        Task<IEnumerable<Menu>> GetMenuUsuarioDapper(int rut, int idApp);
        Task<IEnumerable<Menu>> GetMenuPadre();
    }
}
