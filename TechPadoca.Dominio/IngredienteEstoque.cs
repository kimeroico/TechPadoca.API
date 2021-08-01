using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class IngredienteEstoque : IEntity
    {
        public int Id { get; set; }
        public decimal QuantidadeTotal { get; set; }
        public decimal QuantidadeMinima { get; set; }
        public string Local { get; set; }
        public int IdIngrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }
        

        public void Cadastrar(decimal quantidadeTotal, decimal quantidadeMinima, string local, int idIngrediente)
        {
            QuantidadeTotal = quantidadeTotal;
            QuantidadeMinima = quantidadeMinima;
            Local = local;
            IdIngrediente = idIngrediente;
        }

        public void MandarParaCozinha(decimal quantidadeMandada)
        {
            QuantidadeTotal -= quantidadeMandada;
        }
    }
}
