using Application.Interface;
using AutoMapper;
using Domain.Data;
using Domain.DTOS.Request.CategoriaRequest;
using Domain.DTOS.Response.CategoriaResponse;
using Domain.Model;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoriaService : ICategoria
    {
        private IMapper _mapper;
        private MarketContext _context;
        public CategoriaService(IMapper mapper, MarketContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public Result CadastrarCategoria(CadastrarCategoriaRequestDTO categoriaDTO)
        {
            try
            {
                var verificaCategoria = _context.Categorias.Where(c => c.NomeCategoria.ToUpper() == categoriaDTO.NomeCategoria.ToUpper()).FirstOrDefault();
                if (verificaCategoria != null) return Result.Fail("Categoria já existe!");
                var categoria = _mapper.Map<Categoria>(categoriaDTO);
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return Result.Ok().WithSuccess("Categoria Cadastrado com sucesso!");
            }catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public CategoriaResponseDTO GetCategoria(int id)
        {
            var categoria = _context.Categorias.Where(c => c.Id == id).FirstOrDefault();
            if (categoria == null) return null;
            var dto = _mapper.Map<CategoriaResponseDTO>(categoria);
            return dto;
        }

        public List<CategoriaResponseDTO> GetListCategorias()
        {
            var categorias = _context.Categorias.ToList();
            var listDto = _mapper.Map<List<CategoriaResponseDTO>>(categorias);
            return listDto;
        }
    }
}
