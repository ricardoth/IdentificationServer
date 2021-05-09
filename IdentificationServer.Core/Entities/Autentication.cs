using IdentificationServer.Core.Enumerations;

namespace IdentificationServer.Core.Entities
{
    public class Autentication : BaseEntity
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
    }
}
