using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class ItemVenda : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
        public decimal Quantidade { get; set; }

        public void Cadastrar(int id, Produto produto, Venda venda, decimal quantidade)
        {
            Id = id;
            Produto = produto;
            Venda = venda;
            Quantidade = quantidade;
        }
    }  
}
