using IdentificationServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IPerfilRepository
    {
        Task<IEnumerable<Perfil>> GetPerfils();
        Task<Perfil> Agregar(Perfil perfil);
    }
}
