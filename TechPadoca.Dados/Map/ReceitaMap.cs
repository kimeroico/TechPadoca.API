using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Map
{
    public class ReceitaMap : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receita");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QtdIngrediente).HasColumnType("decimal(20,5)").IsRequired();
        }
    }
}
