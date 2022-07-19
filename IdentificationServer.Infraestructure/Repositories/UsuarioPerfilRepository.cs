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
    public class UsuarioPerfilRepository : BaseRepository<UsuarioPerfil>, IUsuarioPerfilRepository
    {
        public UsuarioPerfilRepository(IdentificationBdContext context) : base(context){ }

        public async Task<IEnumerable<UsuarioPerfil>> GetPerfilesByUsuario(int idUsuario)
        {
            return await _entities.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
