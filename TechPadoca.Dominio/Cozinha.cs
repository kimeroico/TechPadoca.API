using TechPadoca.Dominio.Enum;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Cozinha : IEntity
    {
        public int Id { get; private set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; private set; }
        public decimal QuantidadeProduzida { get; set; }

        public void Cadastrar(int idProduto, decimal quantidadeProduzida)
        {
            IdProduto = idProduto;
            QuantidadeProduzida = quantidadeProduzida;
        }

        public void Alterar(decimal quantidadeProduzida)
        {
            QuantidadeProduzida = (quantidadeProduzida <= 0) ? QuantidadeProduzida : quantidadeProduzida;
        }
    }
}
