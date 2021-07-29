using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Venda : IEntity
    {
        public int Id { get; set; }
        public List<ItemVenda> Items { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }

        public void Cadastrar(int id, List<ItemVenda> items, decimal valorTotal, decimal desconto)
        {           
            Id = id;
            Items.AddRange(items);
            ValorTotal = valorTotal;
            Desconto = desconto;
        }

        public void SolicitarItemVenda(List<ItemVenda> items)
        {
            // entender melhor
        }

        public void VendaConcluida()
        {
            // entender melhor
        }
    }
}
