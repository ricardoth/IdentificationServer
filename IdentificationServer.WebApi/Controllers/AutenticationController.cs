namespace IdentificationServer.WebApi.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IEmailService _emailService;   

        public AutenticationController(
            IUserAuthService userAuthService,
            IMapper mapper, 
            IPasswordService passwordService,
            IUsuarioService usuarioService,
            IEmailService emailService)
        {
            _userAuthService = userAuthService;
            _mapper = mapper;
            _passwordService = passwordService;
            _usuarioService = usuarioService;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto usuarioDto)
        { 
            var authUser = _mapper.Map<Usuario>(usuarioDto);
            authUser.Password = _passwordService.Hash(usuarioDto.Password);

            await _usuarioService.Agregar(authUser);
            usuarioDto = _mapper.Map<UsuarioDto>(authUser);
            var response = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(response);
        }

        [HttpPost("RequestChangePassword")]
        public async Task<IActionResult> RequestChangePassword([FromBody] RequestChangePasswordDto changePasswordDto)
        {
            var emailDto = new EmailDto(changePasswordDto.Correo, "Ha solicitado restablecer su contraseña", "<div><h1><button>Restablezca su Contraseña</button></h1></div>");
            await _emailService.SendEmail(emailDto);
            return Ok(emailDto);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDto userPasswordDto) 
        {
            var userPassword = _mapper.Map<UserResetPassword>(userPasswordDto);
            var usuario = await _userAuthService.GetLoginByEmail(userPassword);
            if (usuario == null)
                return NotFound("El usuario proporcionado no coincide con nuestros registros");

            if (_passwordService.Hash(usuario.Password) != _passwordService.Hash(userPassword.OldPassword))
                return BadRequest("La contraseña proporcionada, no coincide con la contraseña del usuario ingresado, por favor verifique la contraseña");

            usuario.Password = _passwordService.Hash(userPassword.NewPassword);
            var result = await _usuarioService.Actualizar(usuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
