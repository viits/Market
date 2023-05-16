using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> opts): base(opts)
        {
            
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<ProdutoMercado> ProdutosMercados{ get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Lista> Listas { get; set; }
    }
}
