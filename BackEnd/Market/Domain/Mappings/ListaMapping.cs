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
    internal class ListaMapping : IEntityTypeConfiguration<Lista>
    {
        public void Configure(EntityTypeBuilder<Lista> builder)
        {
           builder.HasOne(l=> l.Usuario).WithMany(u=> u.Listas).HasForeignKey(l=>l.UsuarioId);
           builder.HasOne(l=> l.Mercado).WithMany(m=> m.Listas).HasForeignKey(l=>l.UsuarioId);
        }
    }
}
