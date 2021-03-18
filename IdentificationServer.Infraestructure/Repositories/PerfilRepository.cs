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
        private DbSet<Perfil> _dbSet;

        public PerfilRepository(IdentificationBdContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<Perfil>();
        }

        public async Task<IEnumerable<Perfil>> GetPerfils()
        {
            var perfiles = await _context.Perfils.ToListAsync();
            return perfiles;
        }

        public async Task<Perfil> Agregar(Perfil entity)
        {
            _dbSet.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                //_logger.LogError($"Error en {nameof(Agregar)}: " + excepcion.Message);
                return null;
            }
            return entity;
        }
    }
}
