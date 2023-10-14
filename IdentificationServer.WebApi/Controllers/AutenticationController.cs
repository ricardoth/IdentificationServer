namespace IdentificationServer.WebApi.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly IAutenticationService _autenticationService;
        private readonly IUsuarioService _userAuthService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public AutenticationController(IAutenticationService autenticationService,
            IUsuarioService userAuthService,
            IMapper mapper, 
            IPasswordService passwordService)
        {
            _autenticationService = autenticationService;
            _userAuthService = userAuthService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(AutenticationDto autenticationDto)
        //{
        //    var auth = _mapper.Map<Autentication>(autenticationDto);
        //    auth.Password = _passwordService.Hash(auth.Password);

        //    await _autenticationService.RegisterUser(auth);
        //    autenticationDto = _mapper.Map<AutenticationDto>(auth);
        //    var response = new ApiResponse<AutenticationDto>(autenticationDto);
        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto usuarioDto)
        { 
            var authUser = _mapper.Map<Usuario>(usuarioDto);
            authUser.Password = _passwordService.Hash(usuarioDto.Password);

            await _userAuthService.Agregar(authUser);
            usuarioDto = _mapper.Map<UsuarioDto>(authUser);
            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);
        }
    }
}
