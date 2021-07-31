using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechPadoca.API.DTO
{
    public class ItemVendaDTO
    {
        public int IdProduto { get; set; }
        public int IdVenda { get; set; }
        //public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
