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

                var lista = (from l in _contex.Listas
                             join m in _contex.Mercados on l.MercadoId equals m.Id
                             join pm in _contex.ProdutosMercados on  l.MercadoId  equals pm.MercadoId where l.CdProduto == pm.ProdutoId
                             join p in _contex.Produtos on pm.ProdutoId equals p.Id
                             where l.UsuarioId == usuarioId && l.CdProduto == pm.ProdutoId
                             select new ListaResponseDTO
                             {
                                 ListaId = l.Id,
                                 MercadoId = m.Id,
                                 UsuarioId = l.UsuarioId,
                                 NomeMercado = m.NomeMercado,
                                 ValorProduto = pm.Valor,
                                 EnderecoImagem = pm.EnderecoImagem,
                                 ProdutoId = p.Id,
                                 NomeProduto = p.Nome,
                                 QuantidadeProduto = l.QuantidadeProduto
                             }).ToList();

                return lista;
            }
            catch (Exception ex)
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
