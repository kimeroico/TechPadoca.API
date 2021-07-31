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
    public class IngredienteEstoqueMap : IEntityTypeConfiguration<IngredienteEstoque>
    {
        public void Configure(EntityTypeBuilder<IngredienteEstoque> builder)
        {
            builder.ToTable("IngredienteEstoque");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuantidadeTotal).HasColumnType("decimal(20,5)").IsRequired();
            builder.Property(x => x.QuantidadeMinima).HasColumnType("decimal(20,5)").IsRequired();
            builder.Property(x => x.Local).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.IdIngrediente).HasColumnType("int").IsRequired();
            builder.HasOne<Ingrediente>(p => p.Ingrediente)
                .WithOne(d => d.IngredienteEstoque)
                .HasForeignKey<IngredienteEstoque>(i => i.IdIngrediente);
        }
    }
}
