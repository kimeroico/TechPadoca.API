using System.Collections.Generic;
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
        public List<ItemVenda> ItemVendas { get; set; }

        public void Cadastrar(decimal desconto)
        {
            ValorTotal = 0;
            Desconto = desconto;
            var dataAgora = DateTime.Now;
            DataDaVenda = String.Format("{0:yyyy/MM/dd}", dataAgora);
        }

        public void AdicionarTotal(decimal valor)
        {
            ValorTotal = ValorTotal + valor;
        }
    }
}
