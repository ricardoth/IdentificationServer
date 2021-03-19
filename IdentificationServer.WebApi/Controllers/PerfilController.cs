using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilController(IPerfilRepository perfilRepository)
        {
            this._perfilRepository = perfilRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerfils()
        {
            var perfiles = await _perfilRepository.GetPerfils();
            return Ok(perfiles);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(Perfil perfil)
        {
            await _perfilRepository.Agregar(perfil);
            return Ok(perfil);
        }
    }
}
