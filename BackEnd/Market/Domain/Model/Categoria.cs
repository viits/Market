using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string NomeCategoria { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}
