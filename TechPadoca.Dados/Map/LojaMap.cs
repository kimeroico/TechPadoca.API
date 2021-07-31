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
    public class LojaMap : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.ToTable("Loja");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProdutoId).HasColumnType("int").IsRequired();
            builder.Property(x => x.Quantidade).HasColumnType("int").IsRequired();
            builder.Property(x => x.QuantidadeMinima).HasColumnType("int").IsRequired();
            builder.HasOne<Produto>(p => p.Produto).WithOne(d => d.Loja).HasForeignKey<Loja>(i => i.ProdutoId);
        }
    }
}
