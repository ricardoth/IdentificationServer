using AutoMapper;
using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.QueryFilters;
using IdentificationServer.Infraestructure.Interfaces;
using IdentificationServer.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IMenuUsuarioRepository _menuUsuarioService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public MenuController(IMenuService menuService, IMenuUsuarioRepository menuUsuarioService,IMapper mapper, IUriService uriService)
        {
            _menuService = menuService;
            _menuUsuarioService = menuUsuarioService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(GetMenus))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetMenus([FromQuery] MenuQueryFilter filtros)
        {
            var menus = _menuService.GetMenus(filtros);
            var menusDtos = _mapper.Map<IEnumerable<MenuDto>>(menus);

            var metaData = new MetaData
            {
                TotalCount = menus.TotalCount,
                PageSize = menus.PageSize,
                CurrentPage = menus.CurrentPage,
                TotalPages = menus.TotalPages,
                HasNextPage = menus.HasNextPage,
                HasPreviousPage = menus.HasPreviousPage,
                NextPageUrl = _uriService.GetMenuPaginationUri(filtros, Url.RouteUrl(nameof(GetMenus))).ToString(),
                PreviousPageUrl = _uriService.GetMenuPaginationUri(filtros, Url.RouteUrl(nameof(GetMenus))).ToString()
            };

            var response = new ApiResponse<IEnumerable<MenuDto>>(menusDtos)
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
            var menu = await _menuService.GetMenu(id);
            if (menu == null)
                return NotFound();

            var menuDto = _mapper.Map<MenuDto>(menu);
            var response = new ApiResponse<MenuDto>(menuDto);
            return Ok(response);
        }

        [HttpGet("/GetMenuUsuario/{rut}/{idApp}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMenuUsuario(int rut, int idApp)
        {
            var menus = await _menuUsuarioService.GetMenuUsuario(rut, idApp);
            if (menus == null)
                return BadRequest();
            else {
                var menusDto = _mapper.Map<IEnumerable<MenuDto>>(menus);
                var response = new ApiResponse<IEnumerable<MenuDto>>(menusDto); 
                return Ok(response);
            }
        }

        [HttpGet("/GetMenuUsuarioDapper/{rut}/{idApp}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMenuUsuarioDapper(int rut, int idApp)
        {
            var menus = await _menuUsuarioService.GetMenuUsuarioDapper(rut, idApp);
            if (menus == null)
                return BadRequest();
            else {
                var menusDto = _mapper.Map<IEnumerable<MenuDto>>(menus);
                var response = new ApiResponse<IEnumerable<MenuDto>>(menusDto);
                return Ok(response);
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] MenuDto menuDto)
        {
            var menu = _mapper.Map<Menu>(menuDto);
            await _menuService.Agregar(menu);
            menuDto = _mapper.Map<MenuDto>(menu);
            var response = new ApiResponse<MenuDto>(menuDto);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, MenuDto menuDto)
        {
            if (menuDto == null)
                return NotFound();

            var menu = _mapper.Map<Menu>(menuDto);
            menu.Id = id;
            var result = await _menuService.Actualizar(menu);
            if (!result)
                return BadRequest();

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NoContent();

                var result = await _menuService.Eliminar(id);

                if (!result)
                    return BadRequest();

                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
