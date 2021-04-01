using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Exceptions;
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

       
        public async Task Agregar(UsuarioPerfil usuarioPerfil)
        {
            var user = await _unitOfWork.UsuarioRepository.GetById(usuarioPerfil.IdUsuario);
            var perfil = await _unitOfWork.PerfilRepository.GetById(usuarioPerfil.IdPerfil);

            if (user == null)
            {
                throw new BusinessException("Usuario inexistente, no se puede crear la Relación");
            }

            if (perfil == null)
            {
                throw new BusinessException("Perfil inexistente, no se puede crear la Relación");
            }


            await _unitOfWork.UsuarioPerfilRepository.Add(usuarioPerfil);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<bool> Actualizar(UsuarioPerfil usuarioPerfil)
        {
            _unitOfWork.UsuarioPerfilRepository.Update(usuarioPerfil);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _unitOfWork.UsuarioPerfilRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

       
    }
}
