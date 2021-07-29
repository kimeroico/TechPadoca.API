using TechPadoca.Dominio.Enum;

namespace TechPadoca.Dominio
{
    public class Receita
    {
        public int Id { get; set; }
        public Produto ProdFabricado { get; set; }
        public Produto ProdIngrediente { get; set; }
        public decimal QtdIngrediente { get; set; }
        public bool Status { get; set; }

        public void Cadastrar(int id, Produto prodFabricado, Produto prodIngrediente, decimal qtdIngrediente, bool status)
        {
            Id = id;
            ProdFabricado = prodFabricado;
            ProdIngrediente = prodIngrediente;
            QtdIngrediente = qtdIngrediente;
            Status = status;
        }
        public void Alterar(Produto prodFabricado, Produto prodIngrediente, decimal qtdIngrediente)
        {
            ProdFabricado = prodFabricado.Categoria == CategoriaDeProdutoEnum.Proprio ? prodFabricado : ProdFabricado;
            ProdIngrediente = prodIngrediente.Categoria == CategoriaDeProdutoEnum.Ingrediente ? prodIngrediente : ProdIngrediente;
            QtdIngrediente = qtdIngrediente;
        }

        public void Desativar()
        {
            Status = false;
        }
    }
}
