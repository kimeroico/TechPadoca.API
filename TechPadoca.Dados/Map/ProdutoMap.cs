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
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.ValorUnitario).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.HasMany<ItemVenda>(p => p.ItemVenda).WithOne(s => s.Produto).HasForeignKey(i => i.IdProduto);
            builder.HasMany<Receita>(p => p.Receita).WithOne(s => s.Produto).HasForeignKey(i => i.IdProduto);
            builder.HasMany<Cozinha>(p => p.Cozinha).WithOne(s => s.Produto).HasForeignKey(i => i.IdProduto);
        }
    }
}
