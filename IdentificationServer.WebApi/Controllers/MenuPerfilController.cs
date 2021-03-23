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
    public class MenuPerfilController : ControllerBase
    {
        private readonly IMenuPerfilRepository _menuPerfilRepository;
        private readonly IMapper _mapper;

        public MenuPerfilController(IMenuPerfilRepository menuPerfilRepository, IMapper mapper)
        {
            _menuPerfilRepository = menuPerfilRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var menuPerfils = await _menuPerfilRepository.GetMenuPerfils();
            var menuPerfilsDtos = _mapper.Map<IEnumerable<MenuPerfilDto>>(menuPerfils);
            return Ok(menuPerfilsDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var menuPerfils = await _menuPerfilRepository.GetMenuPerfil(id);
            var menuPerfilsDtos = _mapper.Map<MenuPerfilDto>(menuPerfils);
            return Ok(menuPerfilsDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuPerfilDto menuPerfilDto)
        {
            var menuPerfil = _mapper.Map<MenuPerfil>(menuPerfilDto);
            await _menuPerfilRepository.Agregar(menuPerfil);
            return Ok(menuPerfil);
        }
    }
}
