using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Response.ListaResponse
{
    public class ListaResponseDTO
    {
        public int ListaId { get; set; }
        public int ProdutoId { get; set; }
        public int MercadoId { get; set; }
        public string NomeProduto { get; set; }
        public string EnderecoImagem { get; set; }
        public string NomeMercado { get; set; }
        public double ValorProduto { get; set; }
    }
}
