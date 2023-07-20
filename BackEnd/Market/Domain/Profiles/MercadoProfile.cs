using AutoMapper;
using Domain.DTOS.Request.MercadoRequet;
using Domain.DTOS.Response.MercadoResponse;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
{
    public class MercadoProfile : Profile
    {
        public MercadoProfile()
        {
            CreateMap<CadastrarMercadoRequestDTO, Mercado>();
            CreateMap<Mercado, MercadoResponseDTO>();
            CreateMap<UpdateMercadoRequestDTO, Mercado>();
        }
    }
}
