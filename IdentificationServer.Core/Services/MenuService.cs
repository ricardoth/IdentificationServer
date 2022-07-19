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
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public MenuService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
        }


        public PagedList<Menu> GetMenus(MenuQueryFilter filtros)
        {
            filtros.PageNumber = filtros.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filtros.PageNumber;
            filtros.PageSize = filtros.PageSize == 0 ? _paginationOptions.DefaultPageSize : filtros.PageSize;

            var menus = _unitOfWork.MenuRepository.GetAll();

            if (filtros.IdMenu != null)
                menus = menus.Where(x => x.Id == filtros.IdMenu);

            if (filtros.IdApp != null)
                menus = menus.Where(x => x.IdApp == filtros.IdApp);

            if (filtros.Nombre != null)
                menus = menus.Where(x => x.Nombre == filtros.Nombre);

            if (filtros.Padre != null)
                menus = menus.Where(x => x.Padre == filtros.Padre);

            if (filtros.EsActivo != null)
                menus = menus.Where(x => x.EsActivo == filtros.EsActivo);


            var pagedMenus = PagedList<Menu>.Create(menus, filtros.PageNumber, filtros.PageSize);
            return pagedMenus;

        }

        public async Task<Menu> GetMenu(int id)
        {
            return await _unitOfWork.MenuRepository.GetById(id);
        }

        public async Task Agregar(Menu menu)
        {
            await _unitOfWork.MenuRepository.Add(menu);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Actualizar(Menu menu)
        {
            var menuExistente = await _unitOfWork.MenuRepository.GetById(menu.Id);
            menuExistente.IdApp = menu.IdApp;
            menuExistente.Padre = menu.Padre;
            menuExistente.Nombre = menu.Nombre;
            menuExistente.Url = menu.Url;
            menuExistente.UrlFriend = menu.UrlFriend;
            menuExistente.EsActivo = menu.EsActivo;
            menuExistente.EsPadre = menu.EsPadre;
            menuExistente.TieneHijos = menu.TieneHijos;

            _unitOfWork.MenuRepository.Update(menuExistente);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            await _unitOfWork.MenuRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        
    }
}
