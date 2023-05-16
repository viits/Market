using AutoMapper;
using Domain.DTOS.Request.ProdutoRequest;
using Domain.DTOS.Response.ProdutoResponse;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile() {
            CreateMap<CadastrarProdutoRequestDTO, Produto>();
            CreateMap<Produto, ProdutoResponseDTO>();
        }
    }
}
