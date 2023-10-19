using IdentificationServer.Core.Entities;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces.InterfaceServices
{
    public interface IAppService
    {
        Task<App> GetAppById(int id);
    }
}
