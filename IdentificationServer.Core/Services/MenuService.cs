using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
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

        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork.MenuRepository.Update(menu);
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
