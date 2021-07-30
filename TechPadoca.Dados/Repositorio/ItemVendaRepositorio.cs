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

        public bool Incluir(Produto produto, Venda venda, decimal quantidade)
        {
            var itemVenda = new ItemVenda();
            itemVenda.Cadastrar(listaItemVenda.Count + 1, produto, venda, quantidade);
            if (Existe(itemVenda))
            {
                return false;
            }
            listaItemVenda.Add(itemVenda);
            ProdutoVendido(itemVenda.Produto, itemVenda.Quantidade);
            AdicionandoNoTotal(itemVenda.ValorUnitario, itemVenda.Quantidade, itemVenda);
            return true;
        }

        public bool ProdutoVendido(Produto produto, decimal quantidade)
        {
            var produtoNaLoja = new LojaRepositorio();
            produtoNaLoja.ProdutoVendido(produto, quantidade);
            return true;
        }
        
        public bool AdicionandoNoTotal(decimal valor, decimal quantidade, ItemVenda itemVenda)
        {
            var total = valor * quantidade;
            itemVenda.Venda.AdicionarTotal(total);
            return true;
        }

        private bool Existe(ItemVenda venda)
        {
            return listaItemVenda.Any(x => x.Produto == venda.Produto && x.Venda == venda.Venda);
        }

        public List<ItemVenda> SelecionarTudo()
        {
            return listaItemVenda.OrderBy(x => x.Produto).ToList();
        }

    }
}
