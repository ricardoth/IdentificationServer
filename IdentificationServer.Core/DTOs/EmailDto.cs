using System;

namespace IdentificationServer.Core.DTOs
{
    public class EmailDto
    {
        private string ToAddress { get; set; }
        private string Subject { get; set; }
        private string Body { get; set; }

        public EmailDto(string toAddress, string toSubject, string toBody)
        {
            ToAddress = toAddress;
            Subject = toSubject;
            Body = toBody;
        }

        public String GetAddress() => ToAddress;
        public String GetSubject() => Subject;
        public String GetBody() => Body;
    }
}
