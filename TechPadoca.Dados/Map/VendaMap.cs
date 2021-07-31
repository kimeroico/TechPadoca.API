using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Map
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValorTotal).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Desconto).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.DataDaVenda).HasColumnType("varchar(100)").IsRequired();
            builder.HasMany<ItemVenda>(p => p.ItemVendas).WithOne(s => s.Venda).HasForeignKey(i => i.IdVenda);
        }
    }
}
