using IdentificationServer.Core.DTOs;
using IdentificationServer.Infraestructure.Interfaces;
using IdentificationServer.Infraestructure.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigOptions _emailConfig;

        public EmailService(EmailConfigOptions emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendEmail(EmailDto emailDto)
        {
            var email = new MimeMessage();
            email.Subject = emailDto.GetSubject();
            email.From.Add(new MailboxAddress("Remitente", _emailConfig.From));
            email.To.Add(new MailboxAddress("Destinatario", emailDto.GetAddress()));


            var bodyBuilder = new BodyBuilder { HtmlBody = emailDto.GetBody() };
            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.Host, Convert.ToInt32(_emailConfig.Port),
                                MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                var response = await smtp.SendAsync(email);
                smtp.Disconnect(true);
            };
        }
    }
}
