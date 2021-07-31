using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class IngredienteRepositorio : BaseRepositorio<Ingrediente>
    {
        public bool Incluir(string nome)
        {
            var ingrediente = new Ingrediente();
            ingrediente.Cadastrar(nome);

            if (Existe(ingrediente))
            {
                return false;
            }

            return base.Incluir(ingrediente);
        }

        public bool Existe(Ingrediente ingrediente) => contexto.Ingrediente.Any(x => x.Nome == ingrediente.Nome);

    }
}
