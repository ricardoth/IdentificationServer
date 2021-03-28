using AutoMapper;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioService.GetUsuarios();
            var usuariosDtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            var response = new ApiResponse<IEnumerable<UsuarioDto>>(usuariosDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioService.GetUsuario(id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioService.Agregar(usuario);
            usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.Id = id;

            var result = await _usuarioService.Actualizar(usuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usuarioService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
