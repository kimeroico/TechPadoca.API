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

        public bool NovaSolicitacaoDaLoja(Produto produto, int quantidade)
        {
            var novaSolicitacao = new Cozinha();
            novaSolicitacao.Cadastrar(listaCozinha.Count + 1, produto, quantidade);

            if (Existe(novaSolicitacao))
            {

            }


            return true;
        }


        private bool Existe(Cozinha pedido)
        {
            return listaCozinha.Any(x => x.ProdutoFabricado == pedido.ProdutoFabricado
            && x.QuantidadeProduzida == pedido.QuantidadeProduzida
            && x.StatusDeProducao == pedido.StatusDeProducao);
        }
    }
}
