using IdentificationServer.Core.Entities;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces.InterfaceServices
{
    public interface IUserAuthService
    {
        Task<Usuario> GetLoginByCredentials(UserLogin login);
        Task<Usuario> GetLoginByEmail(UserResetPassword login);
    }
}
