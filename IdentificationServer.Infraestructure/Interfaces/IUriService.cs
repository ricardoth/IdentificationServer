using IdentificationServer.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PerfilQueryFilter filter, string actionUrl);
    }
}
