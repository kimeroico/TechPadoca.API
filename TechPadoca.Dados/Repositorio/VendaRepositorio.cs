using System.Collections.Generic;
using System.Linq;
using TechPadoca.Dominio;
using TechPadoca.Dominio.Enum;

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

        public bool AdicionarValorTotal(Venda venda, decimal adicionado)
        {
            venda.AdicionarTotal(adicionado);
            contexto.Venda.Update(venda);
            contexto.SaveChanges();
            return true;
        }
    }

}
