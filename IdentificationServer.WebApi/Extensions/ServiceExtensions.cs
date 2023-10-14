using IdentificationServer.Core.Interfaces;
using IdentificationServer.Core.Interfaces.InterfaceServices;
using IdentificationServer.Core.Interfaces.Repositories;
using IdentificationServer.Core.Services;
using IdentificationServer.Infraestructure.Interfaces;
using IdentificationServer.Infraestructure.Repositories;
using IdentificationServer.Infraestructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDependecies(this IServiceCollection services) 
        {
            services.AddScoped<IUsuarioPerfilRepository, UsuarioPerfilRepository>();
            services.AddTransient<IAutenticationService, AutenticationService>();
            services.AddTransient<IUsuarioPerfilService, UsuarioPerfilService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPerfilService, PerfilService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IMenuUsuarioRepository, MenuUsuarioRepository>();
            services.AddTransient<IUserAuthRepository, UserAuthRepository>();   
            services.AddTransient<IUserAuthService, UserAuthService>();   
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            //var jwtSettings = configuration.GetSection("Authentication");
            //string secretKey = jwtSettings.GetValue<string>("SecretKey");
            //int minutes = jwtSettings.GetValue<int>("MinutesToExpiration");
            //string issuer = jwtSettings.GetValue<string>("Issuer");
            //string audience = jwtSettings.GetValue<string>("Audience");

            //var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey =  true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
                };
            });

        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }
    }
}
