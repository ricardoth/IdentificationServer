using IdentificationServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Core.Interfaces
{
    public interface IAutenticationService
    {
        Task<Autentication> GetLoginByCredentials(UserLogin login);
        Task RegisterUser(Autentication autentication);
    }
}
