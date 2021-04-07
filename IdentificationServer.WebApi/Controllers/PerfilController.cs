using AutoMapper;
using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.QueryFilters;
using IdentificationServer.Infraestructure.Interfaces;
using IdentificationServer.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfilService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public PerfilController(IPerfilService perfilService, IMapper mapper, IUriService uriService)
        {
            this._perfilService = perfilService;
            this._mapper = mapper;
            this._uriService = uriService;
        }

        [HttpGet(Name = nameof(GetPerfils))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPerfils([FromQuery]PerfilQueryFilter filtros)
        {
            var perfiles = _perfilService.GetPerfils(filtros);
            var perfilesDtos = _mapper.Map<IEnumerable<PerfilDto>>(perfiles);

            var metaData = new MetaData
            {
                TotalCount = perfiles.TotalCount,
                PageSize = perfiles.PageSize,
                CurrentPage = perfiles.CurrentPage,
                TotalPages = perfiles.TotalPages,
                HasNextPage = perfiles.HasNextPage,
                HasPreviousPage = perfiles.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filtros, Url.RouteUrl(nameof(GetPerfils))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filtros, Url.RouteUrl(nameof(GetPerfils))).ToString()

            };

            var response = new ApiResponse<IEnumerable<PerfilDto>>(perfilesDtos)
            { 
                Meta = metaData
            };

            Response.Headers.Add("x-Pagination", JsonConvert.SerializeObject(metaData));
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
