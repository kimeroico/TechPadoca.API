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

        public bool Cadastrar(decimal valorTotal, decimal desconto)
        {
            var venda = new Venda();            
            venda.Cadastrar(listaVenda.Count + 1, valorTotal, desconto);
            listaVenda.Add(venda);
            return true;
        }

        public bool AdicionarValorTotal(Venda venda, decimal adicionado)
        {
            venda.AdicionarTotal(adicionado);
            return true;
        }

        public Venda SelecionarPorId(int id)
        {
            return listaVenda.FirstOrDefault(x => x.Id == id);
        }
    }


}
