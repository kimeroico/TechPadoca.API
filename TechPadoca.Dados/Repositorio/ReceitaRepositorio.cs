using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;


namespace TechPadoca.Dados.Repositorio
{
    public class ReceitaRepositorio : BaseRepositorio<Receita>
    {
        public bool Incluir(int idProduto, int idIngrediente, decimal qtdIngrediente)
        {
            var novaReceita = new Receita();
            novaReceita.Cadastrar(idProduto, idIngrediente, qtdIngrediente);
            return base.Incluir(novaReceita);
        }

        //public bool Alterar(int id, Produto prodFabricado, Produto prodIngrediente, decimal qtdIngrediente)
        //{
        //    var alterado = SelecionarPorId(id);

        //    if (Existe(prodFabricado, prodIngrediente))
        //    {
        //        return false;
        //    }

        //    alterado.Alterar(prodFabricado, prodIngrediente, qtdIngrediente);
        //    return true;
        //}

        public List<Receita> SelecionarReceitaCompleta(int id) => contexto.Receita.Where(x => x.IdProduto == id).ToList();
    }
}
