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
    public class CozinhaMap : IEntityTypeConfiguration<Cozinha>
    {
        public void Configure(EntityTypeBuilder<Cozinha> builder)
        {
            builder.ToTable("Cozinha");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuantidadeProduzida).HasColumnType("decimal(20,5)").IsRequired();
        }
    }
}
