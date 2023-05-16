using Application.Interface;
using AutoMapper;
using Domain.Data;
using Domain.DTOS.Request;
using Domain.DTOS.Response.ListaResponse;
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
    public class ListaService : ILista
    {
        private readonly MarketContext _contex;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        public ListaService(MarketContext context,IMapper mapper, IHttpContextAccessor httpContext)
        {
            _contex = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public Result CadastrarLista(CadastrarListaRequestDTO dto)
        {
            try
            {
                var lista = _mapper.Map<Lista>(dto);
                _contex.Listas.Add(lista);
                _contex.SaveChanges();
                return Result.Ok().WithSuccess("Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
        public List<ListaResponseDTO> getList(int usuarioId)
        {
            try
            {
                var lista = _contex.Listas.Where(l => l.MercadoId == usuarioId)
                    .Join(_contex.Mercados, l => l.MercadoId, m=> m.Id ,(l, m) => new
                    {
                        ListaId = l.Id,
                        MercadoId = m.Id,
                        NomeMercado = m.NomeMercado,
                        CdProduto= l.CdProduto
                    })
                    .Join(_contex.ProdutosMercados, l=> l.MercadoId,pm=> pm.MercadoId, (l, pm) => new {
                        ValorProduto = pm.Valor,
                        ListaId = l.ListaId,
                        MercadoId = pm.MercadoId,
                        NomeMercado = l.NomeMercado,
                        EnderecoImagem = pm.EnderecoImagem,
                        CdProduto = l.CdProduto,
                        ProdutoId = pm.ProdutoId
                    }).Where(pm=> pm.ProdutoId == pm.CdProduto)
                    .Join(_contex.Produtos, pm=> pm.CdProduto, p=> p.Id,(pm,p)=> new ListaResponseDTO()
                    {
                        ListaId = pm.ListaId,
                        MercadoId = pm.MercadoId,
                        NomeMercado = pm.NomeMercado,
                        ValorProduto = pm.ValorProduto,
                        EnderecoImagem = pm.EnderecoImagem,
                        ProdutoId = p.Id,
                        NomeProduto = p.Nome
                    }).ToList();
                
                return lista;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CompararListaResponseDTO ComparaPrecos(int mercadoId)
        {
            try
            {
                var usuarioId = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(x => x.Type == "id")?.Value);
                var lista = getList(usuarioId);
                if(lista.Count > 0)
                {
                    List<ListaResponseDTO> mercadoComparar = new List<ListaResponseDTO>();
                    foreach(var item in lista)
                    {
                        var listaMercado = _contex.Mercados.Where(m => m.Id == mercadoId)
                                          .Join(_contex.ProdutosMercados, m => m.Id, pm => pm.MercadoId, (m, pm) => new ListaResponseDTO()
                                          {
                                              ProdutoId = pm.ProdutoId,
                                              MercadoId = m.Id,
                                              NomeMercado = m.NomeMercado,
                                              EnderecoImagem = pm.EnderecoImagem,
                                              ValorProduto = pm.Valor
                                          }).Join(_contex.Produtos,pm=> pm.ProdutoId,p=> p.Id,(pm,p)=> new ListaResponseDTO()
                                          {
                                              ProdutoId = pm.ProdutoId,
                                              MercadoId = pm.MercadoId,
                                              NomeMercado = pm.NomeMercado,
                                              EnderecoImagem = pm.EnderecoImagem,
                                              ValorProduto = pm.ValorProduto,
                                              NomeProduto = p.Nome
                                          }).Where(pm => pm.ProdutoId == item.ProdutoId).FirstOrDefault();
                        Console.WriteLine("Produto: " + listaMercado);
                         if(listaMercado != null)
                        {
                            mercadoComparar.Add(listaMercado);
                        }
                    }
                    CompararListaResponseDTO mercados = new CompararListaResponseDTO(lista, mercadoComparar);
                    return mercados;
                }
                return null;
              
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
