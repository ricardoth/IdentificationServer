namespace IdentificationServer.Core.Entities
{
    public class UserResetPassword
    {
        public string? Username { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string Correo { get; set; }
    }
}
