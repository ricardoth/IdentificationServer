using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Services
{
    public class AutenticationService : IAutenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Autentication> GetLoginByCredentials(UserLogin login)
        {
            return await _unitOfWork.AutenticationRepository.GetLoginByCredentials(login);        
        }

        public async Task RegisterUser(Autentication autentication)
        {
            await _unitOfWork.AutenticationRepository.Add(autentication);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}