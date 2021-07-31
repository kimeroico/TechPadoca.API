using TechPadoca.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace TechPadoca.Dados.Repositorio
{
    public class ItemVendaRepositorio : BaseRepositorio<ItemVenda>
    {
        public bool Incluir(Produto produto, Venda venda, int quantidade)
        {
            var itemVenda = new ItemVenda();
            itemVenda.Cadastrar(produto.Id, venda.Id, quantidade, produto.ValorUnitario);
            if (Existe(itemVenda))
            {
                return false;
            }
            
            return base.Incluir(itemVenda);
        }        

        public bool AtualizarVenda(int id)
        {
            var item = SelecionarPorId(id);
            var total = (decimal)item.ValorUnitario * item.Quantidade;
            var venda = new VendaRepositorio();
            venda.AdicionarValorTotal(item.IdVenda, total);
            return true;
        }

        public bool AtualizarLoja(int id)
        {
            var item = SelecionarPorId(id);
            var total = item.Quantidade;
            var loja = new LojaRepositorio();
            loja.ProdutoVendido(item.IdVenda, total);
            return true;
        }

        private bool Existe(ItemVenda venda)
        {
            return contexto.ItemVenda.Any(x => x.Produto == venda.Produto && x.Venda == venda.Venda);
        }

        public override List<ItemVenda> SelecionarTudo()
        {
            return base.SelecionarTudo().OrderBy(x => x.Id).ToList();
        }

    }
}
