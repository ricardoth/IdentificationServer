using AutoMapper;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Enumerations;
using IdentificationServer.Core.Interfaces;
using IdentificationServer.Infraestructure.Interfaces;
using IdentificationServer.WebApi.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly IAutenticationService _autenticationService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public AutenticationController(IAutenticationService autenticationService, IMapper mapper, IPasswordService passwordService)
        {
            _autenticationService = autenticationService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AutenticationDto autenticationDto)
        {
            var auth = _mapper.Map<Autentication>(autenticationDto);
            auth.Password = _passwordService.Hash(auth.Password);

            await _autenticationService.RegisterUser(auth);
            autenticationDto = _mapper.Map<AutenticationDto>(auth);
            var response = new ApiResponse<AutenticationDto>(autenticationDto);
            return Ok(response);
        }
    }
}
