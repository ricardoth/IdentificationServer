using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _unitOfWork.UsuarioRepository.GetById(id);
        }

        public async Task Agregar(Usuario usuario)
        {
            await _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            _unitOfWork.UsuarioRepository.Update(usuario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _unitOfWork.UsuarioRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
