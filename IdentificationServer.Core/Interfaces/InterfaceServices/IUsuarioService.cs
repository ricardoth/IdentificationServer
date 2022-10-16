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
    public interface IUsuarioService
    {
        PagedList<Usuario> GetUsuarios(UsuarioQueryFilter filtros);
        Task<Usuario> GetUsuario(int id);
        Task Agregar(Usuario usuario);
        Task<bool> Actualizar(Usuario usuario);
        Task<bool> Eliminar(int id);
    }
}
