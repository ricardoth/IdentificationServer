using IdentificationServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Perfil> PerfilRepository { get; } 
        IRepository<Usuario> UsuarioRepository { get; }
        IRepository<Menu> MenuRepository { get; }
        IRepository<App> AppRepository { get; }
        IUsuarioPerfilRepository UsuarioPerfilRepository { get; }
        IAutenticationRepository AutenticationRepository{ get; }

        //Se deben incluir todos los repositorios genéricos
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
