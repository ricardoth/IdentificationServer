using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IUnitOfWork _unitOfWork;    

        public PerfilService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Perfil> GetPerfils()
        {
            return _unitOfWork.PerfilRepository.GetAll();
        }

        public async Task<Perfil> GetPerfil(int id)
        {
            return await _unitOfWork.PerfilRepository.GetById(id);
        }

        public async Task Agregar(Perfil perfil)
        {
            if (perfil.Nombre.Contains("sexo"))
            {
                throw new Exception("Debe escribir un nombre coherente");
            }
            await _unitOfWork.PerfilRepository.Add(perfil);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Actualizar(Perfil perfil)
        {
            _unitOfWork.PerfilRepository.Update(perfil);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _unitOfWork.PerfilRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
