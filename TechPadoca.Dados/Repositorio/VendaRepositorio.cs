using System.Collections.Generic;
using System.Linq;
using TechPadoca.Dominio;


namespace TechPadoca.Dados.Repositorio
{
    public class VendaRepositorio
    {
        private List<Venda> listaVenda { get; set; }

        public VendaRepositorio()
        {
            listaVenda = new List<Venda>();
        }

        public void Cadastrar(List<ItemVenda> items, decimal valorTotal, decimal desconto)
        {
            Venda venda = new Venda();
            
            venda.Cadastrar(listaVenda.Count + 1, items, valorTotal, desconto);
            listaVenda.Add(venda);
        }


    }
}
