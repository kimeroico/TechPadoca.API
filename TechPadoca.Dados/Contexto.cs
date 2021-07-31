using Microsoft.EntityFrameworkCore;
using TechPadoca.Dados.Map;
using TechPadoca.Dominio;

namespace TechPadoca.Dados
{
    public class Contexto : DbContext
    {
        public DbSet<Cozinha> Cozinha { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<IngredienteEstoque> IngredienteEstoque { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KIMEROICO; Database=TechPadoca; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CozinhaMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            modelBuilder.ApplyConfiguration(new ItemVendaMap());
            modelBuilder.ApplyConfiguration(new LojaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ReceitaMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new IngredienteMap());
            modelBuilder.ApplyConfiguration(new IngredienteEstoqueMap());

        }
    }
}
