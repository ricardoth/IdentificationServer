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
            CreateMap<Perfil, PerfilDto>()
                .ForMember(dest => dest.IdPerfil, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<MenuPerfil, MenuPerfilDto>().ReverseMap();
            CreateMap<UsuarioPerfil, UsuarioPerfilDto>().ReverseMap();
            CreateMap<Autentication, AutenticationDto>().ReverseMap();
        }
    }
}
