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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProdutoMercadoService : IProdutoMercado
    {
        private readonly IMapper _mapper;
        private MarketContext _marketContext;
        private readonly IHttpContextAccessor _httpContext;
        public ProdutoMercadoService(IMapper mapper, MarketContext marketContext, IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _marketContext = marketContext;
            _httpContext = httpContext;
        }

        public Result CadastrarProdutoMercado(CadastrarProdutoMercadoRequestDTO dto)
        {
            try
            {
                dto.MercadoId = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(x => x.Type == "id")?.Value);
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
            try
            {
                var produto = _mapper.Map<Produto>(produtoDto);
                _marketContext.Produtos.Add(produto);
                return Result.Ok().WithSuccess("Cadastrado com sucesso");
            }catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
        public ProdutoMercadoResponseDTO GetProdutoMercadoById(int id)
        {
            return _mapper.Map<ProdutoMercadoResponseDTO>(_marketContext.ProdutosMercados.Where(pm => pm.IdProdutoMercado == id).FirstOrDefault());
        }
        public List<ProdutoMercadoResponseDTO> TodosProdutosMercados(int mercadoId)
        {
            try
            {
                var produtoMercado = _marketContext.ProdutosMercados
                    .Join(
                    _marketContext.Produtos,
                    pm => pm.ProdutoId, p => p.Id,
                    (pm, p) => new ProdutoMercadoResponseDTO()
                    {
                        IdProdutoMercado = pm.IdProdutoMercado,
                        MercadoId = pm.MercadoId,
                        ProdutoId = pm.ProdutoId,
                        NomeProduto = p.Nome,
                        DescricaoProduto = p.Descricao,
                        EnderecoImagem = pm.EnderecoImagem,
                        ValorProduto = pm.Valor,
                    }).Where(pm => pm.MercadoId == mercadoId).ToList();
                return produtoMercado;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
