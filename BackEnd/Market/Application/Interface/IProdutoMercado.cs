using Domain.DTOS.Request.ProdutoMercadoRequest;
using Domain.DTOS.Request.ProdutoRequest;
using Domain.DTOS.Response.ProdutoMercadoResponse;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IProdutoMercado
    {
        Result CadastrarProdutoMercado(CadastrarProdutoMercadoRequestDTO requestDTO);
        Result CadastrarNovoProduto(CadastrarProdutoRequestDTO dto);
        List<ProdutoMercadoResponseDTO> TodosProdutosMercados(int mercadoId);
    }
}
