using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechPadoca.API.DTO
{
    public class EstoqueDTO
    {
        public int QuantidadeTotal { get; set; }
        public int QuantidadeMinima { get; set; }
        public int IdProduto { get; set; }
        public string Local { get; set; }
    }
}
