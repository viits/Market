using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Mercado
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string NomeMercado { get; set; }
        [Required]
        public string EnderecoMercado { get; set; }
        [Required]
        public string NumeroEndereco { get; set; }
        [Required]
        public string NomeBairro { get; set; }
        public int Ativo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public virtual IList<ProdutoMercado> ProdutoMercado { get; set; }
        public virtual List<Lista> Listas { get; set; }
    }
}
