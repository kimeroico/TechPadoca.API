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
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("ItemVendas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValorUnitario).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnType("int").IsRequired();
        }
    }
}
