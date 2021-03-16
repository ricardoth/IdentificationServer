using IdentificationServer.Core.Interfaces;
using IdentificationServer.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDependecies(this IServiceCollection services) 
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
