using AutoMapper;
using IdentificationServer.Core.DTOs;
using IdentificationServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentificationServer.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Perfil, PerfilDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<MenuPerfil, MenuPerfilDto>().ReverseMap();
        }
    }
}
