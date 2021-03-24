﻿using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentificationBdContext _context;
        private readonly IRepository<Perfil> _perfilRepository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public UnitOfWork(IdentificationBdContext context)
        {
            _context = context;
        }

        public IRepository<Perfil> PerfilRepository => _perfilRepository ?? new BaseRepository<Perfil>(_context);

        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new BaseRepository<Usuario>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}