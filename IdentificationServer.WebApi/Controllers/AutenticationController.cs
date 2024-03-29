﻿namespace IdentificationServer.WebApi.Controllers
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDto userPasswordDto) 
        {
            var userPassword = _mapper.Map<UserResetPassword>(userPasswordDto);
            var usuario = await _userAuthService.GetLoginByEmail(userPassword);
            if (usuario == null)
                return NotFound("El usuario proporcionado no coincide con nuestros registros");

            if (!_passwordService.Check(_passwordService.Hash(userPasswordDto.ConfirmPassword), userPassword.NewPassword))
                return BadRequest("La contraseña debe ser igual a la de confirmación. Por favor verifique su contraseña");

            if (_passwordService.Check(usuario.Password, userPassword.NewPassword))
                return BadRequest("La contraseña no puede ser igual a la anterior");

            usuario.Password = _passwordService.Hash(userPassword.NewPassword);
            var result = await _usuarioService.Actualizar(usuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
