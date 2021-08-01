using System.Collections.Generic;
using System.Linq;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class VendaRepositorio : BaseRepositorio<Venda>
    {
        public bool Incluir(decimal desconto)
        {
            var venda = new Venda();            
            venda.Cadastrar(desconto);
            return base.Incluir(venda);
        }

        public bool AdicionarValorTotal(int idVenda, decimal adicionado)
        {
            var x = SelecionarPorId(idVenda);
            x.AdicionarTotal(adicionado);
            contexto.Venda.Update(x);
            contexto.SaveChanges();
            return true;
        }
    }
}
