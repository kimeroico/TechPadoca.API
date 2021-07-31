using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class ItemVenda : IEntity
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int IdVenda { get; set; }
        public Venda Venda { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public void Cadastrar(int idProduto, int idVenda, int quantidade, decimal valorUnitario)
        {
            IdProduto = idProduto;
            IdVenda = idVenda;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
        }

    }  
}
