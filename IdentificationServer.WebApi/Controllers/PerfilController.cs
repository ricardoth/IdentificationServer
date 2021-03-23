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
        private readonly IPerfilService _perfilService;
        private readonly IMapper _mapper;

        public PerfilController(IPerfilService perfilService, IMapper mapper)
        {
            this._perfilService = perfilService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerfils()
        {
            var perfiles = await _perfilService.GetPerfils();
            var perfilesDtos = _mapper.Map<IEnumerable<PerfilDto>>(perfiles);
            var response = new ApiResponse<IEnumerable<PerfilDto>>(perfilesDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfil(int id)
        {
            var perfil = await _perfilService.GetPerfil(id);
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
            await _perfilService.Agregar(perfil);
            perfilDto = _mapper.Map<PerfilDto>(perfil);
            var response = new ApiResponse<PerfilDto>(perfilDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PerfilDto perfilDto)
        {
            var perfil = _mapper.Map<Perfil>(perfilDto);
            perfil.Id = id;
            var result = await _perfilService.Actualizar(perfil);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _perfilService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
