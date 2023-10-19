using IdentificationServer.Core.DTOs;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailDto emailDto);
        string GetTemplateResetPassword(string urlCambioContrasena);
    }
}
