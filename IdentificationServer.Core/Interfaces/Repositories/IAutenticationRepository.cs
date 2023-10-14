using IdentificationServer.Core.Entities;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IAutenticationRepository : IRepository<Autentication>
    {
        Task<Autentication> GetLoginByCredentials(UserLogin login);
    }
}
