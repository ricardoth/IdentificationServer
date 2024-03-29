﻿namespace IdentificationServer.WebApi.Controllers
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CargarProceso([FromBody] List<ClienteDto> request)
        {
            var clientes = _mapper.Map<List<Cliente>>(request);
            var result = await _clienteService.CargarProcesoClientes(clientes);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
            
        }
    }
}
