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
                return false;
            }

            listaCozinha.Add(novaSolicitacao);
            return true;
        }

        public bool AlterarSolicitacao(int id, int quantidade)
        {
            var alterado = SelecionarPorId(id);
            alterado.Alterar(quantidade);
            return true;
        }

        public bool VerificarReceita(Cozinha solicitacao)
        {
            var receita = new ReceitaRepositorio();
            var listaReceita = receita.SelecionarReceitaCompleta(solicitacao.ProdutoFabricado.Id);

            foreach (var x in listaReceita)
            {
                var n = new EstoqueRepositorio();
                n.MandarParaCozinha(x.QtdIngrediente, x.ProdIngrediente);

            }

            return true;
        }

        public Cozinha SelecionarPorId(int id) => listaCozinha.FirstOrDefault(x => x.Id == id);

        private bool Existe(Cozinha pedido)
        {
            return listaCozinha.Any(x => x.ProdutoFabricado == pedido.ProdutoFabricado
            && x.QuantidadeProduzida == pedido.QuantidadeProduzida
            && x.StatusDeProducao == pedido.StatusDeProducao);
        }
    }
}
