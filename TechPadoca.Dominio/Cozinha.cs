using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Cozinha : IEntity
    {
        public int Id { get; private set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; private set; }
        public int QuantidadeProduzida { get; set; }

        public void Cadastrar(int idProduto, int quantidadeProduzida)
        {
            IdProduto = idProduto;
            QuantidadeProduzida = quantidadeProduzida;
        }

        //public void Alterar(int quantidadeProduzida)
        //{
        //    QuantidadeProduzida = (quantidadeProduzida <= 0) ? QuantidadeProduzida : quantidadeProduzida;
        //}
    }
}
