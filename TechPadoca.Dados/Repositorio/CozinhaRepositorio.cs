using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class CozinhaRepositorio : BaseRepositorio<Cozinha>
    {
        public bool Incluir(int idProduto, int quantidade)
        {
            var novaSolicitacao = new Cozinha();
            novaSolicitacao.Cadastrar(idProduto, quantidade);
            return base.Incluir(novaSolicitacao);
        }

        public bool ExecutandoProcesso(int idCozinha)
        {
            var cozinha = SelecionarPorId(idCozinha);
            var receita = new ReceitaRepositorio();
            var listaReceita = receita.SelecionarReceitaCompleta(cozinha.IdProduto);

            if (VerificarNoEstoque(listaReceita, cozinha))
            {
                return false;
            }

            RetiraDoEstoque(listaReceita, cozinha);
            return true;
        }

        private void RetiraDoEstoque(List<Receita> lista, Cozinha solicitacao)
        {
            foreach (var x in lista)
            {
                var n = new IngredienteEstoqueRepositorio();
                n.MandarParaCozinha(x.IdIngrediente, (x.QtdIngrediente * solicitacao.QuantidadeProduzida));
            }
        }

        public bool EntregarParaLoja(int idCozinha)
        {
            var cozinha = SelecionarPorId(idCozinha);
            var p = cozinha.IdProduto;
            var loja = new LojaRepositorio();
            loja.ReceberProdutoDaCozinha(p, cozinha.QuantidadeProduzida);
            return true;
        }

        private bool VerificarNoEstoque(List<Receita> lista, Cozinha solicitacao)
        {
            var count = 0;
            foreach (var x in lista)
            {
                var n = new IngredienteEstoqueRepositorio();
                if (n.VerificaQuantidade(x.IdIngrediente, (x.QtdIngrediente * solicitacao.QuantidadeProduzida)))
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
