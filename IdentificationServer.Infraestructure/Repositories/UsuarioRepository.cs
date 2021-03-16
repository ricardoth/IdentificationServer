﻿using IdentificationServer.Core.Entities;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IdentificationBdContext _context;

        public UsuarioRepository(IdentificationBdContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

    }
}
