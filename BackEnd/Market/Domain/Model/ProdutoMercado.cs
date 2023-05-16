using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProdutoMercado
    {
        [Key]
        [Required]
        public int IdProdutoMercado { get; set; }
        [Required]
        public double Valor { get; set; }
        public string EnderecoImagem { get; set; }
        public int MercadoId { get; set; }
        public int ProdutoId { get; set; }
        public virtual Mercado Mercado { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
