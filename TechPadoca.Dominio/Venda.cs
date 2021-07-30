using TechPadoca.Dominio.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio.Interface;
using System;

namespace TechPadoca.Dominio
{
    public class Venda : IEntity
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public string DataDaVenda { get; set; }

        public void Cadastrar(int id, decimal valorTotal, decimal desconto)
        {
            Id = id;
            ValorTotal = valorTotal;
            Desconto = desconto;
            var dataAgora = DateTime.Now;
            DataDaVenda = String.Format("{0:yyyy/MM/dd}", dataAgora);
        }

        public void AdicionarTotal(decimal valor)
        {
            if (valor > 0)
            {
                ValorTotal += valor;
            }
        }
    }
}
