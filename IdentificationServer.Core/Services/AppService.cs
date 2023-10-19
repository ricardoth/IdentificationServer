using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.Interfaces.InterfaceServices;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Services
{
    public class AppService : IAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<App> GetAppById(int id)
        {
            return await _unitOfWork.AppRepository.GetById(id);
        }
    }
}
