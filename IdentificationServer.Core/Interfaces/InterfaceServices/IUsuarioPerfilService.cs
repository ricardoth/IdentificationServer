using IdentificationServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IUsuarioPerfilService
    {
        IEnumerable<UsuarioPerfil> GetUsuarioPerfils();
        Task<UsuarioPerfil> GetUsuarioPerfil(int id);
        Task Agregar(UsuarioPerfil usuarioPerfil);
        Task<bool> Actualizar(UsuarioPerfil usuarioPerfil);
        Task<bool> Eliminar(int id);
    }
}
