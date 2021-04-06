﻿using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.QueryFilters;
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

        public PagedList<Perfil> GetPerfils(PerfilQueryFilter filtros)
        {
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
