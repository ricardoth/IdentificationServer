using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.QueryFilters;
using IdentificationServer.Infraestructure.Options;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public PerfilService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
        }

        public PagedList<Perfil> GetPerfils(PerfilQueryFilter filtros)
        {
            filtros.PageNumber = filtros.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filtros.PageNumber;
            filtros.PageSize = filtros.PageSize == 0 ? _paginationOptions.DefaultPageSize : filtros.PageSize;

            var perfiles = _unitOfWork.PerfilRepository.GetAll();

            if (filtros.IdPerfil != null)
            {
                perfiles = perfiles.Where(x => x.Id == filtros.IdPerfil);
            }

            if (filtros.Nombre != null)
            {
                perfiles = perfiles.Where(x => x.Nombre.ToLower().Contains(filtros.Nombre.ToLower()));
            }

            if (filtros.EsActivo != null)
            {
                perfiles = perfiles.Where(x => x.EsActivo == filtros.EsActivo);
            }

            var pagedPerfiles = PagedList<Perfil>.Create(perfiles, filtros.PageNumber, filtros.PageSize);

            return pagedPerfiles;
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
            var perfilExistente = await _unitOfWork.PerfilRepository.GetById(perfil.Id);
            perfilExistente.Nombre = perfil.Nombre;
            perfilExistente.EsActivo = perfil.EsActivo;

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
