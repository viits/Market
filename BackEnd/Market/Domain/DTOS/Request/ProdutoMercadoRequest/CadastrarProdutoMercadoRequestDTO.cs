using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Request.ProdutoMercadoRequest
{
    public class CadastrarProdutoMercadoRequestDTO
    {
        [Required]
        public double Valor { get; set; }
        public string EnderecoImagem { get; set; }
        public int MercadoId { get; set; }
        public int ProdutoId { get; set; }
    }
}
