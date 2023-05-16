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
    public class MercadoMapping : IEntityTypeConfiguration<Mercado>
    {
        public void Configure(EntityTypeBuilder<Mercado> builder)
        {
            builder.HasMany(m => m.ProdutoMercado).WithOne(pm => pm.Mercado).HasForeignKey(pm => pm.MercadoId);
            builder.HasMany(m => m.Listas).WithOne(l => l.Mercado).HasForeignKey(l => l.MercadoId);
        }
    }
}
