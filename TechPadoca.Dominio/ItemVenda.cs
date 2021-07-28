using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechPadoca.Dominio
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
        public decimal Quantidade { get; set; }

        public void Cadastrar(int id, Produto produto, Venda venda, decimal quantidade)
        {
            Id = id;
            Produto = produto;
            Venda = venda;
            Quantidade = quantidade;
        }
    }  
}
