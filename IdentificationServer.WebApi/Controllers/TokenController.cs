namespace IdentificationServer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAutenticationService _autenticationService;
        private readonly IUserAuthService _userAuthService;
        private readonly IPasswordService _passwordService;
        public TokenController(IConfiguration configuration
            ,IAutenticationService autenticationService
            ,IPasswordService passwordService
            ,IUserAuthService userAuthService)
        {
            _configuration = configuration;
            _autenticationService = autenticationService;
            _userAuthService = userAuthService;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }
            return NotFound();
        }

        private async Task<(bool, Usuario)> IsValidUser(UserLogin login)
        {
            //var user = await _autenticationService.GetLoginByCredentials(login);
            var user = await _userAuthService.GetLoginByCredentials(login);
            if (user != null)
            {
                var isValid = _passwordService.Check(user.Password, login.Password);
                return (isValid, user);
            }
           return (false, null);
        }

        private string GenerateToken(Usuario usuario)
        {
            //Headers
            var _symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(_symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim("User", usuario.Username),
                //new Claim(ClaimTypes.Role, autentication.Role.ToString()),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
