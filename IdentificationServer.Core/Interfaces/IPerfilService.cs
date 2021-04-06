using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IPerfilService
    {
        PagedList<Perfil> GetPerfils(PerfilQueryFilter filtros);
        Task<Perfil> GetPerfil(int id);
        Task Agregar(Perfil perfil);
        Task<bool> Actualizar(Perfil perfil);
        Task<bool> Eliminar(int id);
    }
}