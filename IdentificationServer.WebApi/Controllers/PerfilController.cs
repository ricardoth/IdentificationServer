using AutoMapper;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.WebApi.Responses;
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
            var response = new ApiResponse<IEnumerable<PerfilDto>>(perfilesDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfil(int id)
        {
            var perfil = await _perfilRepository.GetPerfil(id);
            var perfilDto = _mapper.Map<PerfilDto>(perfil);
            var response = new ApiResponse<PerfilDto>(perfilDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(PerfilDto perfilDto)
        {
            var perfil = _mapper.Map<Perfil>(perfilDto);
            await _perfilRepository.Agregar(perfil);
            perfilDto = _mapper.Map<PerfilDto>(perfil);
            var response = new ApiResponse<PerfilDto>(perfilDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PerfilDto perfilDto)
        {
            var perfil = _mapper.Map<Perfil>(perfilDto);
            perfil.IdPerfil = id;
            var result = await _perfilRepository.Actualizar(perfil);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _perfilRepository.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
