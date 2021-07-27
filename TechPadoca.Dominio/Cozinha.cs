using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio.Services;

namespace TechPadoca.Dominio
{
    public class Cozinha : ISolicitacaoEstoque
    {
        public int Id { get; set; }
        public Produto ProdutoFabricado { get; set; }
        public int QauntidadeProduzida { get; set; }
        public Receita Receita { get; set; }

        
        
        void SolicitarIngredientes()
        {
           
        }

        void VerificarReceita()
        {

        }

        void EnviarProdutoPronto()
        {

        }
    }
}
