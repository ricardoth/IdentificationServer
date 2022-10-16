using IdentificationServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces.InterfaceServices
{
    public interface IClienteService
    {
        Task<bool> CargarProcesoClientes(List<Cliente> clientes);
    }
}
