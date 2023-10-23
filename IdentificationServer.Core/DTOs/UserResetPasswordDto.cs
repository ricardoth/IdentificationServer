namespace IdentificationServer.Core.DTOs
{
    public class UserResetPasswordDto
    {
        public string? Username { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string Correo { get; set; }
    }
}
