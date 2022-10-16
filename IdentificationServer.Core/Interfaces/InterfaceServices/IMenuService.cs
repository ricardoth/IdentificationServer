using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.QueryFilters;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IMenuService
    {
        PagedList<Menu> GetMenus(MenuQueryFilter filtros);
        Task<Menu> GetMenu(int id);
        Task Agregar(Menu menu);
        Task<bool> Actualizar(Menu menu);
        Task<bool> Eliminar(int id);
    }
}
