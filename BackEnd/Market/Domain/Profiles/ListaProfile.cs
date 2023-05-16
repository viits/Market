using AutoMapper;
using Domain.DTOS.Request;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Profiles
{
    public class ListaProfile : Profile
    {
        public ListaProfile()
        {
            CreateMap<CadastrarListaRequestDTO, Lista>();
        }
    }
}
