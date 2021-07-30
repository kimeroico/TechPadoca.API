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

        public void Cadastrar(Produto produto, decimal quantidade)
        {
            ItemVenda itemVenda = new ItemVenda();

            //Verificar se existe na loja ou receber da loja...

            itemVenda.Cadastrar(listaItemVenda.Count + 1, produto, quantidade);
            listaItemVenda.Add(itemVenda);
        }
        public List<ItemVenda> SelecionarTudo()
        {
            return listaItemVenda.OrderBy(x => x.Produto).ToList();
        }

    }
}
