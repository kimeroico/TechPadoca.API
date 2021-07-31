using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechPadoca.API.DTO
{
    public class IngredienteEstoqueDTO
    {
        public decimal QuantidadeTotal { get; set; }
        public decimal QuantidadeMinima { get; set; }
        public string Local { get; set; }
        public int IdIngrediente { get; set; }
    }
}
