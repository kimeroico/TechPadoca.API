using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class CozinhaRepositorio
    {
        private List<Cozinha> listaCozinha;

        public CozinhaRepositorio()
        {
            listaCozinha = new List<Cozinha>();
        }
    }
}
