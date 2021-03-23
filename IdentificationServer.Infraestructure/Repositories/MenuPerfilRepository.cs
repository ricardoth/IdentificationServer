using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Repositories
{
    public class MenuPerfilRepository : IMenuPerfilRepository
    {
        private readonly IdentificationBdContext _context;

        public MenuPerfilRepository(IdentificationBdContext context)
        {
            _context = context;   
        }

        public async Task<IEnumerable<MenuPerfil>> GetMenuPerfils()
        {
            var menuPerfiles = await _context.MenuPerfils.ToListAsync();
            return menuPerfiles;
        }

        public async Task<MenuPerfil> GetMenuPerfil(int id)
        {
            var menuPerfil = await _context.MenuPerfils.SingleOrDefaultAsync(x => x.IdMenuPerfil == id);
            return menuPerfil;
        }

        public async Task<MenuPerfil> Agregar(MenuPerfil menuPerfil)
        {
            _context.MenuPerfils.Add(menuPerfil);
            await _context.SaveChangesAsync();
            return menuPerfil;
        }

        public async Task<bool> Actualizar(MenuPerfil menuPerfil)
        {
            var perfilBd = await GetMenuPerfil(menuPerfil.IdMenuPerfil);
            perfilBd.EsActivo = menuPerfil.EsActivo;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var menuPerfilBd = await GetMenuPerfil(id);
            _context.MenuPerfils.Remove(menuPerfilBd);
            int rowAffected = await _context.SaveChangesAsync();
            return rowAffected > 0;
        }
    }
}
