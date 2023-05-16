using AutoMapper;
using Domain.DTOS.Request.ProdutoMercadoRequest;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
{
    public class ProdutoMercadoProfile : Profile
    {
        public ProdutoMercadoProfile()
        {
            CreateMap<CadastrarProdutoMercadoRequestDTO, ProdutoMercado>();
        }
    }
}
