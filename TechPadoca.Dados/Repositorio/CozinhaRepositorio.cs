using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;
using TechPadoca.Dominio.Enum;

namespace TechPadoca.Dados.Repositorio
{
    public class CozinhaRepositorio : BaseRepositorio<Cozinha>
    {
        public bool Incluir(int idProduto, decimal quantidade)
        {
            var novaSolicitacao = new Cozinha();
            novaSolicitacao.Cadastrar(idProduto, quantidade);
            return base.Incluir(novaSolicitacao);
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
                if (n.VerificarQuantidade(x.ProdIngrediente, x.QtdIngrediente * solicitacao.QuantidadeProduzida))
                {
                    count++;
                }
            }
            if (count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
