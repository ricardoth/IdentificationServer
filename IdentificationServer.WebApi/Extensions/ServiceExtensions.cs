using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.Services;
using IdentificationServer.Infraestructure.Interfaces;
using IdentificationServer.Infraestructure.Repositories;
using IdentificationServer.Infraestructure.Services;
using Microsoft.AspNetCore.Http;
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
            services.AddScoped<IUsuarioPerfilRepository, UsuarioPerfilRepository>();
            services.AddTransient<IUsuarioPerfilService, UsuarioPerfilService>();
            services.AddTransient<IPerfilService, PerfilService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
        }
    }
}
