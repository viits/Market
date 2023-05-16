using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Request.ProdutoRequest
{
    public class CadastrarProdutoRequestDTO
    {
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
    }
}
