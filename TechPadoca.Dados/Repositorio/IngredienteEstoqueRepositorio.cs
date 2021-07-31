using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class IngredienteEstoqueRepositorio : BaseRepositorio<IngredienteEstoque>
    {
        public bool Incluir(decimal quantidadeTotal, decimal quantidadeMinima, string local, int idIngrediente)
        {
            var inEstoque = new IngredienteEstoque();
            inEstoque.Cadastrar(quantidadeTotal, quantidadeMinima, local, idIngrediente);

            if (Existe(inEstoque))
            {
                return false;
            }

            return base.Incluir(inEstoque);
        }

        public bool VerificaQuantidade(int idIngrediente, decimal quantidade)
        {
            var selecao = SelecionaPeloIdIngrediente(idIngrediente);
            if (selecao.QuantidadeTotal < quantidade)
            {
                return true;
            }
            return false;
        }

        public bool MandarParaCozinha(int idIngrediente, decimal quantidade)
        {
            var selecao = SelecionaPeloIdIngrediente(idIngrediente);
            selecao.MandarParaCozinha(quantidade);
            contexto.IngredienteEstoque.Update(selecao);
            contexto.SaveChanges();
            return true;
        }

        private IngredienteEstoque SelecionaPeloIdIngrediente(int id)
        {
            return contexto.IngredienteEstoque.FirstOrDefault(x => x.IdIngrediente == id);
        }
        private bool Existe(IngredienteEstoque a) => contexto.IngredienteEstoque.Any(x => x.IdIngrediente == a.IdIngrediente);
    }
}
