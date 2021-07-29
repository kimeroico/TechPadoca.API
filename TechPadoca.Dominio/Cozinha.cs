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

        public void Alterar(Produto produtoFabricado, int quantidadeProduzida)
        {
            ProdutoFabricado = produtoFabricado.Categoria != CategoriaDeProdutoEnum.Proprio ? ProdutoFabricado : produtoFabricado;
            QuantidadeProduzida = (quantidadeProduzida <= 0) ? QuantidadeProduzida : quantidadeProduzida;
        }

        public void AlterarStatus(ProducaoStatusEnum idStatus) 
        {
            StatusDeProducao = idStatus;
        }
    }
}
