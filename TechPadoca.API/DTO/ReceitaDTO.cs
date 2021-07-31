using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechPadoca.API.DTO
{
    public class ReceitaDTO
    {
        public int IdProduto { get; set; }
        public int IdIngrediente { get; set; }
        public decimal QtdIngrediente { get; set; }
    }
}
