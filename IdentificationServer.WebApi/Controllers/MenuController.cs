using AutoMapper;
using IdentificationServer.Core.CustomEntities;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.QueryFilters;
using IdentificationServer.Infraestructure.Interfaces;
using IdentificationServer.WebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public MenuController(IMenuService menuService, IMapper mapper, IUriService uriService)
        {
            _menuService = menuService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(GetMenus))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetMenus([FromQuery]MenuQueryFilter filtros)
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
        public async Task<IActionResult> Get(int id)
        {
            var menu = await _menuService.GetMenu(id);
            var menuDto = _mapper.Map<MenuDto>(menu);

            var response = new ApiResponse<MenuDto>(menuDto);
            return Ok(response);
        }
    }
}
