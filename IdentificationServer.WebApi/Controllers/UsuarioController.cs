using AutoMapper;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioController(IRepository<Usuario> usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioRepository.GetAll();
            var usuariosDtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            return Ok(usuariosDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioRepository.GetById(id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return Ok(usuarioDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepository.Add(usuario);
            return Ok(usuario);
        }
    }
}
