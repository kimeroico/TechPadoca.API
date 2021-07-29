using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;
using TechPadoca.Dominio.Enum;


namespace TechPadoca.Dados.Repositorio
{
    public class ReceitaRepositorio
    {
        private List<Receita> listaDaReceita;

        public ReceitaRepositorio()
        {
            listaDaReceita = new List<Receita>();
        }

        public bool Incluir(Produto prodFabricado, Produto prodIngrediente, decimal qtdIngrediente)
        {
            var novaReceita = new Receita();
            novaReceita.Cadastrar(listaDaReceita.Count + 1, prodFabricado, prodIngrediente, qtdIngrediente);

            if (Existe(novaReceita))
            {
                return false;
            }

            listaDaReceita.Add(novaReceita);
            return true;
        }

        public bool Alterar(int id, Produto prodFabricado, Produto prodIngrediente, decimal qtdIngrediente)
        {
            var alterado = SelecionarPorId(id);

            if (Existe(prodFabricado, prodIngrediente))
            {
                return false;
            }

            alterado.Alterar(prodFabricado, prodIngrediente, qtdIngrediente);
            return true;
        }

        public List<Receita> SelecionarReceitaCompleta(int id) => listaDaReceita.Where(x => x.ProdFabricado.Id == id).ToList();

        public Receita SelecionarPorId(int id) => listaDaReceita.FirstOrDefault(x => x.Id == id);

        private bool Existe(Receita receita) => listaDaReceita.Any(x => x.ProdFabricado == receita.ProdFabricado && x.ProdIngrediente == receita.ProdIngrediente);

        private bool Existe(Produto prodFabricado, Produto prodIngrediente) => listaDaReceita.Any(x => x.ProdFabricado == prodFabricado && x.ProdIngrediente == prodIngrediente);
    }
}
