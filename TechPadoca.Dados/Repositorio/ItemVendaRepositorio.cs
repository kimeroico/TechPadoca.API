using TechPadoca.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace TechPadoca.Dados.Repositorio
{
    public class ItemVendaRepositorio : BaseRepositorio<ItemVenda>
    {
        public bool Incluir(Produto produto, Venda venda, decimal quantidade)
        {
            var itemVenda = new ItemVenda();
            itemVenda.Cadastrar(produto, venda, quantidade);
            if (Existe(itemVenda))
            {
                return false;
            }
            base.Incluir(itemVenda);
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
            return contexto.ItemVenda.Any(x => x.Produto == venda.Produto && x.Venda == venda.Venda);
        }

        public override List<ItemVenda> SelecionarTudo()
        {
            return base.SelecionarTudo().OrderBy(x => x.Produto.Nome).ToList();
        }

    }
}
