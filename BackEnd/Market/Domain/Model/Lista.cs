using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Lista
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string NomeLista { get; set; }
        public int CdProduto { get; set; }
        public int UsuarioId { get; set; }
        public int MercadoId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Mercado Mercado { get; set; }

    }
}
