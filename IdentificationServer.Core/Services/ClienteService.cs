using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces.InterfaceServices;
using IdentificationServer.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> CargarProcesoClientes(List<Cliente> clientes)
        {
            try
            {
                if (clientes.Count > 0)
                {
                    foreach (var item in clientes)
                    {
                        await _clienteRepository.CargarProcesoClientes(item);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //log
                
            }
            return false;
        }
    }
}
