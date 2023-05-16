using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class ProdutoMercadoMapping : IEntityTypeConfiguration<ProdutoMercado>
    {
        public void Configure(EntityTypeBuilder<ProdutoMercado> builder)
        {
            builder.HasOne(pm => pm.Produto).WithMany(p => p.ProdutoMercado).HasForeignKey(pm => pm.ProdutoId);
            builder.HasOne(pm => pm.Mercado).WithMany(m => m.ProdutoMercado).HasForeignKey(pm => pm.MercadoId);
        }
    }
}
