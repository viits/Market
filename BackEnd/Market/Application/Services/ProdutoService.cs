using Application.Interface;
using AutoMapper;
using Domain.Data;
using Domain.DTOS.Request.ProdutoRequest;
using Domain.DTOS.Response.ProdutoResponse;
using Domain.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProdutoService : IProduto
    {
        private readonly MarketContext _context;
        private readonly IMapper _mapper;
        public ProdutoService(MarketContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Result CadastrarProduto(CadastrarProdutoRequestDTO produtoDTO)
        {
            try
            {
                var produto = _mapper.Map<Produto>(produtoDTO);
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return Result.Ok().WithSuccess("Produto Cadastrado com sucesso!");
            }catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public ProdutoResponseDTO GetProdutoId(int id)
        {
            try
            {
                var produto = _context.Produtos.Where(p => p.Id == id).FirstOrDefault();
                if (produto == null) return null;
                return _mapper.Map<ProdutoResponseDTO>(produto);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProdutoResponseDTO> GetProdutoList()
        {
            var produtoDto = _context.Produtos.Join(_context.Categorias, p=> p.CategoriaId, c=> c.Id, (p, c) => new ProdutoResponseDTO 
            {
                Id= p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                CategoriaId = p.CategoriaId,
                NomeCategoria = c.NomeCategoria
            }).ToList();

            return produtoDto;
        }
    }
}
