using Domain.DTOS.Request;
using Domain.DTOS.Response.ListaResponse;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILista
    {
        Result CadastrarLista(CadastrarListaRequestDTO dto);
        List<ListaResponseDTO> getList(int usuarioId);
        CompararListaResponseDTO ComparaPrecos(int mercadoId);
    }
}
