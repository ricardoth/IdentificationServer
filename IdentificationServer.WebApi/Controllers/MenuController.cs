using AutoMapper;
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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuController(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
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
