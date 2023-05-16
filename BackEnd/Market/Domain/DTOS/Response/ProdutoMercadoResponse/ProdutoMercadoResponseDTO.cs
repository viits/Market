using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Response.ProdutoMercadoResponse
{
    public class ProdutoMercadoResponseDTO
    {
        public int IdProdutoMercado { get; set; }
        public int MercadoId { get; set; }
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public double ValorProduto { get; set; }
        public string EnderecoImagem { get; set; }

    }
}
