using AutoMapper;
using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.QueryFilters;
using IdentificationServer.Infraestructure.Interfaces;
using IdentificationServer.WebApi.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public UsuarioController(IUsuarioService usuarioService, IUsuarioRepository usuarioRepository,IMapper mapper, IUriService uriService)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(GetUsuarios))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetUsuarios([FromQuery]UsuarioQueryFilter filtros)
        {
            var usuarios = _usuarioService.GetUsuarios(filtros);
            var usuariosDtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            var metaData = new MetaData
            {
                TotalCount = usuarios.TotalCount,
                PageSize = usuarios.PageSize,
                CurrentPage = usuarios.CurrentPage,
                TotalPages = usuarios.TotalPages,
                HasNextPage = usuarios.HasNextPage,
                HasPreviousPage = usuarios.HasPreviousPage,
                NextPageUrl = _uriService.GetUsuarioPaginationUri(filtros, Url.RouteUrl(nameof(GetUsuarios))).ToString(),
                PreviousPageUrl = _uriService.GetUsuarioPaginationUri(filtros, Url.RouteUrl(nameof(GetUsuarios))).ToString(),
            };

            var response = new ApiResponse<IEnumerable<UsuarioDto>>(usuariosDtos)
            {
                Meta = metaData
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioService.GetUsuario(id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id,UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.Id = id;

            var result = await _usuarioService.Actualizar(usuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usuarioService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        #region Endpoints de Procedimientos Almacenados

        [HttpGet("/api/GetInfoUsuario/{user}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetInfoUsuario(string user)
        { 
            var usuario = await _usuarioRepository.GetInfoUsuario(user);
            if (usuario == null)
                return BadRequest();
            else
            {
                var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
                var response = new ApiResponse<UsuarioDto>(usuarioDto);
                return Ok(response);
            }

        }
        #endregion

    }
}
