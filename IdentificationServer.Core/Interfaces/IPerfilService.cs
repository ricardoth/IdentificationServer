using IdentificationServer.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IPerfilService
    {
        Task<IEnumerable<Perfil>> GetPerfils();
        Task<Perfil> GetPerfil(int id);
        Task Agregar(Perfil perfil);
        Task<bool> Actualizar(Perfil perfil);
        Task<bool> Eliminar(int id);
    }
}