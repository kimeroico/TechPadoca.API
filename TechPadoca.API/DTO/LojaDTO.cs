using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechPadoca.API.DTO
{
    public class LojaDTO
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}
