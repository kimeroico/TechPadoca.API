//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using TechPadoca.Dominio;

//namespace TechPadoca.Dados.Map
//{
//    public class ReceitaMap : IEntityTypeConfiguration<Receita>
//    {
//        public void Configure(EntityTypeBuilder<Receita> builder)
//        {
//            builder.ToTable("Receita");
//            builder.HasKey(x => x.Id);
//            builder.Property(x => x.IdProdFabricado).HasColumnType("int").IsRequired();
//            builder.Property(x => x.IdProdIngrediente).HasColumnType("int").IsRequired();
//            builder.Property(x => x.QtdIngrediente).HasColumnType("decima(20,5)").IsRequired();
//            builder.HasOne<Produto>(p => p.ProdFabricado).WithOne(d => d.Receita).HasForeignKey<Receita>(i => i.IdProdFabricado);
//            builder.HasOne<Produto>(p => p.ProdIngrediente).WithOne(d => d.Receita).HasForeignKey<Receita>(i => i.IdProdIngrediente);
//        }
//    }
//}
