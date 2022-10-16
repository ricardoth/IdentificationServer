using AutoMapper;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.Interfaces.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoCargaController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ProcesoCargaController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;  
        }

        [HttpPost]
        public async Task<IActionResult> CargarProceso([FromBody] List<ClienteDto> request)
        {
            var clientes = _mapper.Map<List<Cliente>>(request);
            var result = await _clienteService.CargarProcesoClientes(clientes);
            if (result)
                return Ok(request);
            else
                return BadRequest(result);
            
        }
    }
}
