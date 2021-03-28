using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Services
{
    public class UsuarioPerfilService : IUsuarioPerfilService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioPerfilService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UsuarioPerfil> GetUsuarioPerfils()
        {
            return _unitOfWork.UsuarioPerfilRepository.GetAll();
        }

        public async Task<UsuarioPerfil> GetUsuarioPerfil(int id)
        {
            return await _unitOfWork.UsuarioPerfilRepository.GetById(id);
        }

       
        public Task Agregar(UsuarioPerfil usuarioPerfil)
        {
            throw new NotImplementedException();
        }


        public Task<bool> Actualizar(UsuarioPerfil usuarioPerfil)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
