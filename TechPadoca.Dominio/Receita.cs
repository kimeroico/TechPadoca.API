using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Receita : IEntity
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int IdIngrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }
        public decimal QtdIngrediente { get; set; }

        public void Cadastrar(int idProduto, int idIngrediente, decimal qtdIngrediente)
        {
            IdProduto = idProduto;
            IdIngrediente = idIngrediente;
            QtdIngrediente = qtdIngrediente;
        }
        //public void Alterar(int idProduto, int idIngrediente, decimal qtdIngrediente)
        //{
        //    ProdFabricado = prodFabricado.Categoria == CategoriaDeProdutoEnum.Proprio ? prodFabricado : ProdFabricado;
        //    ProdIngrediente = prodIngrediente.Categoria == CategoriaDeProdutoEnum.Ingrediente ? prodIngrediente : ProdIngrediente;
        //    QtdIngrediente = qtdIngrediente;
        //}
    }
}
