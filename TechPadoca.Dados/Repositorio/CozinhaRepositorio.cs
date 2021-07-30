using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;
using TechPadoca.Dominio.Enum;

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
            ExecutandoProcesso(novaSolicitacao);
            return true;
        }

        public bool AlterarSolicitacao(int id, int quantidade)
        {
            var alterado = SelecionarPorId(id);
            alterado.Alterar(quantidade);
            return true;
        }

        public bool ExecutandoProcesso(Cozinha solicitacao)
        {
            var receita = new ReceitaRepositorio();
            var listaReceita = receita.SelecionarReceitaCompleta(solicitacao.ProdutoFabricado.Id);

            if (VerificarNoEstoque(listaReceita, solicitacao))
            {
                return false;
            }

            RetiraDoEstoque(listaReceita, solicitacao);
            return true;
        }

        private void RetiraDoEstoque(List<Receita> lista, Cozinha solicitacao)
        {
            foreach (var x in lista)
            {
                var n = new EstoqueRepositorio();
                n.MandarParaCozinha(x.QtdIngrediente * solicitacao.QuantidadeProduzida, x.ProdIngrediente);
            }
            solicitacao.AlterarStatus(ProducaoStatusEnum.Produzindo);
        }

        private bool VerificarNoEstoque(List<Receita> lista, Cozinha solicitacao)
        {
            var count = 0;
            foreach (var x in lista)
            {
                var n = new EstoqueRepositorio();
                if (n.VerificarQuantidade(x.ProdIngrediente, x.QtdIngrediente*solicitacao.QuantidadeProduzida))
                {
                    count++;
                }
            }
            if (count > 0)
            {
                solicitacao.AlterarStatus(ProducaoStatusEnum.Cancelado);
                return true;
            }            
            return false;
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
