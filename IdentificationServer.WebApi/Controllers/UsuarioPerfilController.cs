﻿using AutoMapper;
using IdentificationServer.Core.DTOs;
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
    public class UsuarioPerfilController : ControllerBase
    {
        private readonly IUsuarioPerfilService _usuarioPerfilService;
        private readonly IUsuarioPerfilRepository _usuarioPerfilRepository;
        private readonly IMapper _mapper;

        public UsuarioPerfilController(IUsuarioPerfilService usuarioPerfilService, IUsuarioPerfilRepository usuarioPerfilRepository,
            IMapper mapper)
        {
            _usuarioPerfilService = usuarioPerfilService;
            _usuarioPerfilRepository = usuarioPerfilRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsuarioPerfil()
        {
            var usuarioPerfiles = _usuarioPerfilService.GetUsuarioPerfils();
            var usuarioPerfilDtos = _mapper.Map<IEnumerable<UsuarioPerfilDto>>(usuarioPerfiles);
            var result = new ApiResponse<IEnumerable<UsuarioPerfilDto>>(usuarioPerfilDtos);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetPerfilesByUsuario")]
        public async Task<IActionResult> GetPerfilesByUsuario(int id)
        {
            var usuarioPerfiles = await _usuarioPerfilRepository.GetPerfilesByUsuario(id);
            var usuarioPerfilesDto = _mapper.Map<IEnumerable<UsuarioPerfilDto>>(usuarioPerfiles);
            var result = new ApiResponse<IEnumerable<UsuarioPerfilDto>>(usuarioPerfilesDto);
            return Ok(result);
        }

    }
}
