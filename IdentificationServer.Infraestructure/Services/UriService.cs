using IdentificationServer.Core.QueryFilters;
using IdentificationServer.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPerfilPaginationUri(PerfilQueryFilter filter, string actionUrl)
        {
            string url = $"{_baseUri}{actionUrl}";
            return new Uri(url);
        }

        public Uri GetUsuarioPaginationUri(UsuarioQueryFilter filter, string actionUrl)
        {
            string url = $"{_baseUri}{actionUrl}";
            return new Uri(url);
        }
    }
}
