using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.QueryFilters;
using IdentificationServer.Infraestructure.Options;
using Microsoft.Extensions.Options;
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
        private readonly PaginationOptions _paginationOptions;

        public UsuarioService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
        }

        public PagedList<Usuario> GetUsuarios(UsuarioQueryFilter filtros)
        {
            filtros.PageNumber = filtros.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filtros.PageNumber;
            filtros.PageSize = filtros.PageSize == 0 ? _paginationOptions.DefaultPageSize : filtros.PageSize;

            var usuarios = _unitOfWork.UsuarioRepository.GetAll();

            if (filtros.Rut != null)
            {
                usuarios = usuarios.Where(x => x.Rut == filtros.Rut);
            }

            if (filtros.Nombre != null)
            {
                usuarios = usuarios.Where(x => x.Nombre.ToLower().Contains(filtros.Nombre.ToLower()));
            }

            if (filtros.ApellidoPaterno != null)
            {
                usuarios = usuarios.Where(x => x.ApellidoPaterno.ToLower().Contains(filtros.ApellidoPaterno.ToLower()));
            }

            if (filtros.EsActivo != null)
            {
                usuarios = usuarios.Where(x => x.EsActivo == filtros.EsActivo);
            }

            var pagedList = PagedList<Usuario>.Create(usuarios, filtros.PageNumber,filtros.PageSize);
            return pagedList;
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
