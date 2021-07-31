using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechPadoca.API.DTO
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Descricao { get; set; }
    }
}
