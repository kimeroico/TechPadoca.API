using TechPadoca.Dominio;
using System.Collections.Generic;
using System.Linq;


namespace TechPadoca.Dados.Repositorio
{
    public class ItemVendaRepositorio
    {
        private List<ItemVenda> listaItemVenda { get; set; }

        public ItemVendaRepositorio()
        {
            listaItemVenda = new List<ItemVenda>();
        }

        public void Cadastrar(Produto produto, Venda venda, decimal quantidade)
        {
            ItemVenda itemVenda = new ItemVenda();

            itemVenda.Cadastrar(listaItemVenda.Count + 1, produto, venda, quantidade);
            listaItemVenda.Add(itemVenda);
        }
    }
}
