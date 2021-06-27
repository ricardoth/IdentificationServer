using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IMenuService
    {
        //PagedList<Menu> GetMenus(PerfilQueryFilter filtros);
        Task<Menu> GetMenu(int id);
        Task Agregar(Menu menu);
        Task<bool> Actualizar(Menu menu);
        Task<bool> Eliminar(int id);
    }
}
