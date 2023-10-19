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
        private readonly IAppService _appService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IEmailService _emailService;   

        public AutenticationController(
            IUserAuthService userAuthService,
            IMapper mapper, 
            IPasswordService passwordService,
            IUsuarioService usuarioService,
            IAppService appService,
            IEmailService emailService)
        {
            _userAuthService = userAuthService;
            _mapper = mapper;
            _passwordService = passwordService;
            _usuarioService = usuarioService;
            _emailService = emailService;
            _appService = appService;
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
            var userResetPassword = new UserResetPassword()
            { 
                Correo = changePasswordDto.Correo,  
            };

            var usuario = await _userAuthService.GetLoginByEmail(userResetPassword);
            if (usuario == null)
                return NotFound("El correo proporcionado no coincide con nuestros registros");

            var app = await _appService.GetAppById(changePasswordDto.IdApp);
            if (app == null)
                return NotFound("El Usuario no tiene acceso a la aplicación");

            var templateEmail = _emailService.GetTemplateResetPassword(app.UrlCambioContrasena);
            var emailDto = new EmailDto(changePasswordDto.Correo, "Ha solicitado restablecer su contraseña", templateEmail);
            await _emailService.SendEmail(emailDto);
            return Ok(changePasswordDto);
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
