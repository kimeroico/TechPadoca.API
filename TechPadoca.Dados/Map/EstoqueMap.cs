using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Map
{
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuantidadeMinima).HasColumnType("decima(20,5)").IsRequired();
            builder.Property(x => x.QuantidadeTotal).HasColumnType("decima(20,5)").IsRequired();            
            builder.Property(x => x.IdProduto).HasColumnType("int").IsRequired();
            builder.Property(x => x.Local).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.QtdTipo).HasColumnType("int").IsRequired();
            builder.HasOne<Produto>(p => p.Produto).WithOne(d => d.Estoque).HasForeignKey<Estoque>(i => i.IdProduto);
        }
    }
}
