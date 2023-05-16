using AutoMapper;
using Domain.DTOS.Request.CategoriaRequest;
using Domain.DTOS.Response.CategoriaResponse;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CadastrarCategoriaRequestDTO, Categoria>();
            CreateMap<Categoria, CategoriaResponseDTO>();
        }
    }
}
