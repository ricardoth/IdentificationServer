using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces.InterfaceServices;
using IdentificationServer.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserAuthRepository _userAuthRepository;
        public UserAuthService(IUserAuthRepository userAuthRepository)
        {
            _userAuthRepository = userAuthRepository;
        }

        public async Task<Usuario> GetLoginByCredentials(UserLogin login)
        {
            return await _userAuthRepository.GetLoginByCredentials(login);
        }
    }
}
