using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        public readonly IdentificationBdContext _context;

        public PerfilRepository(IdentificationBdContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Perfil>> GetPerfils()
        {
            var perfiles = await _context.Perfils.ToListAsync();
            return perfiles;
        }

        public async Task<Perfil> GetPerfil(int id)
        {
            var perfil = await _context.Perfils.SingleOrDefaultAsync(x => x.IdPerfil == id);
            return perfil;
        }

        public async Task<Perfil> Agregar(Perfil perfil)
        {
            _context.Perfils.Add(perfil);
            await _context.SaveChangesAsync();
            return perfil;
        }

        public async Task<bool> Actualizar(Perfil perfil)
        {
            var perfilBd = await GetPerfil(perfil.IdPerfil);
            perfilBd.Nombre = perfil.Nombre;
            perfilBd.EsActivo = perfil.EsActivo;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var perfilBd = await GetPerfil(id);
            _context.Perfils.Remove(perfilBd);
            int rowAffected = await _context.SaveChangesAsync();
            return rowAffected > 0;
        }
    }
}
