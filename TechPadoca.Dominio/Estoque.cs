using System;

namespace TechPadoca.Dominio
{
    public class Estoque
    {
        public int Id { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeMinima { get; set; }
        public Produto Produto { get; set; }
        public string Local { get; set; }
    }
}