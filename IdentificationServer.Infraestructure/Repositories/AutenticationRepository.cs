using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Repositories
{
    public class AutenticationRepository : BaseRepository<Autentication>, IAutenticationRepository
    {
        public AutenticationRepository(IdentificationBdContext context) : base(context)
        {
        }

        public async Task<Autentication> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}
