using TechPadoca.Dominio.Enum;

namespace TechPadoca.Dominio
{
    public class Cozinha
    {
        public int Id { get; private set; }
        public Produto ProdutoFabricado { get; private set; }
        public int QuantidadeProduzida { get; set; }
        public ProducaoStatusEnum StatusDeProducao { get; set; }

        public void Cadastrar(int id, Produto produtoFabricado, int quantidadeProduzida)
        {
            Id = id;
            ProdutoFabricado = produtoFabricado;
            QuantidadeProduzida = quantidadeProduzida;
            StatusDeProducao = ProducaoStatusEnum.Recebido;
        }
        public void VerificarReceita()
        {

        }

        public void SolicitarIngredientes()
        {
           
        }

        public void EnviarProdutoPronto()
        {

        }
    }
}
