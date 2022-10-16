using IdentificationServer.Core.Entities;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetInfoUsuario(string user);
    }
}
