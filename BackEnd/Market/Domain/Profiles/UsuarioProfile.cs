using AutoMapper;
using Domain.DTOS.Request.UsuarioRequest;
using Domain.DTOS.Response.UsuarioResponse;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CadastrarUsuarioRequestDTO,Usuario>();
            CreateMap<Usuario,UsuarioResponseDTO>();
        }
    }
}
