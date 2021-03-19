using AutoMapper;
using IdentificationServer.Core.DTOs;
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
        private readonly IMapper _mapper;

        public PerfilController(IPerfilRepository perfilRepository, IMapper mapper)
        {
            this._perfilRepository = perfilRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerfils()
        {
            var perfiles = await _perfilRepository.GetPerfils();
            var perfilesDtos = _mapper.Map<IEnumerable<PerfilDto>>(perfiles);
            return Ok(perfilesDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfil(int id)
        {
            var perfil = await _perfilRepository.GetPerfil(id);
            var perfilDto = _mapper.Map<PerfilDto>(perfil);
            return Ok(perfilDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(PerfilDto perfilDto)
        {
            var perfil = _mapper.Map<Perfil>(perfilDto);
            await _perfilRepository.Agregar(perfil);
            return Ok(perfil);
        }
    }
}
