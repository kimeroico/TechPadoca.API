using TechPadoca.Dominio.Enum;
using System.Collections.Generic;


namespace TechPadoca.Dominio
{
    public class Venda
    {
        public int Id { get; set; }
        public List<ItemVenda> Items { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public StatusDaVenda Status { get; set; }

        public void Cadastrar(int id, List<ItemVenda> items, decimal valorTotal, decimal desconto)
        {           
            Id = id;
            Items.AddRange(items);
            ValorTotal = valorTotal;
            Desconto = desconto;
            Status = StatusDaVenda.Iniciada;
        }
        public override string ToString()
        {
            return $"{Items} | {ValorTotal} | {Desconto} | {Status}";
        }
    }
}
