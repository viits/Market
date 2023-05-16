using Domain.DTOS.Request.CategoriaRequest;
using Domain.DTOS.Response.CategoriaResponse;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICategoria
    {
        Result CadastrarCategoria(CadastrarCategoriaRequestDTO categoriaDTO);
        CategoriaResponseDTO GetCategoria(int id);
        List<CategoriaResponseDTO> GetListCategorias();
    }
}
