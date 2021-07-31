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


        private bool Existe(IngredienteEstoque a) => contexto.IngredienteEstoque.Any(x => x.IdIngrediente == a.IdIngrediente);
    }
}
