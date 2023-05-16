using Application.Interface;
using AutoMapper;
using Domain.Data;
using Domain.DTOS.Request.ProdutoMercadoRequest;
using Domain.DTOS.Request.ProdutoRequest;
using Domain.DTOS.Response.ProdutoMercadoResponse;
using Domain.Model;
using FluentResults;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProdutoMercadoService : IProdutoMercado
    {
        private readonly IMapper _mapper;
        private MarketContext _marketContext;
       
        public ProdutoMercadoService(IMapper mapper, MarketContext marketContext)
        {
            _mapper = mapper;
            _marketContext = marketContext;
           
        }

        public Result CadastrarProdutoMercado(CadastrarProdutoMercadoRequestDTO dto)
        {
            try
            {
                var produtoMercado = _mapper.Map<ProdutoMercado>(dto);
                _marketContext.ProdutosMercados.Add(produtoMercado);
                _marketContext.SaveChanges();
                return Result.Ok().WithSuccess("Cadastrado com sucesso!");
            }catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
        public Result CadastrarNovoProduto(CadastrarProdutoRequestDTO produtoDto)
        {
            return Result.Ok();
        }
        public ProdutoMercadoResponseDTO GetProdutoMercadoById(int id)
        {
            return _mapper.Map<ProdutoMercadoResponseDTO>(_marketContext.ProdutosMercados.Where(pm => pm.IdProdutoMercado == id).FirstOrDefault());
        }
        public List<ProdutoMercadoResponseDTO> TodosProdutosMercados(int mercadoId)
        {
            try
            {
                var produtoMercado = _marketContext.ProdutosMercados.Where(pm => pm.MercadoId == mercadoId)
                    .Join(
                    _marketContext.Produtos,
                    pm => pm.ProdutoId, p => p.Id,
                    (pm, p) => new ProdutoMercadoResponseDTO()
                    {
                        IdProdutoMercado = pm.IdProdutoMercado,
                        MercadoId = pm.MercadoId,
                        ProdutoId = mercadoId,
                        NomeProduto = p.Nome,
                        DescricaoProduto = p.Descricao,
                        EnderecoImagem = pm.EnderecoImagem,
                        ValorProduto = pm.Valor,
                    }).ToList();
                return produtoMercado;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
