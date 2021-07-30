using System.Collections.Generic;
using System.Linq;
using TechPadoca.Dominio;
using TechPadoca.Dominio.Enum;

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
        public void VendaConcluida(Venda venda)
        {
            LojaRepositorio itemsVendidos = new LojaRepositorio();
            var produtosVendidos = itemsVendidos.SelecionarTudo();

            foreach(var p in produtosVendidos)
            {
                itemsVendidos.ProdutoVendido(p.Produto, p.Quantidade);
            }
            venda.Status = StatusDaVenda.Terminada;
        }
        public Venda SelecionarPorId(int id)
        {
            return listaVenda.FirstOrDefault(x => x.Id == id);
        }
    }


}
