using Domain.DTOS.Request.ProdutoRequest;
using Domain.DTOS.Response.ProdutoResponse;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProduto
    {
        Result CadastrarProduto(CadastrarProdutoRequestDTO produtoDTO);
        ProdutoResponseDTO GetProdutoId(int id);
        List<ProdutoResponseDTO> GetProdutoList();
    }
}
