using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Ingrediente : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IngredienteEstoque IngredienteEstoque { get; set; }
        public List<Receita> Receita { get; set; }

        public void Cadastrar(string nome)
        {
            Nome = nome;
        }
    }
}
