using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces.Repositories;
using IdentificationServer.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Repositories
{
    public class UserAuthRepository : BaseRepository<Usuario>, IUserAuthRepository
    {
        public UserAuthRepository(IdentificationBdContext context) : base(context) { }
     
        public async Task<Usuario> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Username == login.User);
        }

        public async Task<Usuario> GetLoginByEmail(UserResetPassword login) 
        {
            return await _entities.FirstOrDefaultAsync(x => x.Correo == login.Correo);
        }
    }
}
