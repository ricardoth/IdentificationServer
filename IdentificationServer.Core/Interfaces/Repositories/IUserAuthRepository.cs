using IdentificationServer.Core.Entities;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces.Repositories
{
    public interface IUserAuthRepository
    {
        Task<Usuario> GetLoginByCredentials(UserLogin login);
        Task<Usuario> GetLoginByEmail(UserResetPassword login);
    }
}
