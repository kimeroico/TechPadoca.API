using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class LojaRepositorio
    {
        private List<Loja> listaDaLoja;

        public LojaRepositorio()
        {
            listaDaLoja = new List<Loja>();
        }

        public bool Incluir(Produto produto, decimal quantidade, decimal quantidadeMinima, int qrdTipo)
        {
            var produtoLoja = new Loja();
            produtoLoja.Cadastrar(listaDaLoja.Count + 1, produto, quantidade, quantidadeMinima, qrdTipo);

            if (ValidandoDuplicidade(produtoLoja))
            {
                return false;
            }

            listaDaLoja.Add(produtoLoja);
            return true;
        }

        public bool Alterar(int id, decimal quantidade, decimal quantidadeMinima)
        {
            var objeto = SelecionePorId(id);
            objeto.Alterar(quantidade, quantidadeMinima);
            return true;
        }

        public void SolicitarProdutoDoEstoque(Produto produto, decimal quantidadeSolicita)
        {
            var solicitado = SelecionePorIdProduto(produto);
            var estoque = new EstoqueRepositorio();

            if(estoque.MandarParaLoja(quantidadeSolicita, solicitado.Produto))
            {
                solicitado.AdicionarProduto(quantidadeSolicita);
            }

        }

        public void SolicitarProdutoParaCozinha(Produto produto, decimal quantidadeSolicita)
        {
            var solicitado = SelecionePorIdProduto(produto);
            var cozinha = new CozinhaRepositorio();

            if (cozinha.NovaSolicitacaoDaLoja(solicitado.Produto, quantidadeSolicita))
            {
                solicitado.AdicionarProduto(quantidadeSolicita);
            }
        }

        public bool ProdutoVendido(Produto produto, decimal quantidadeVendida)
        {
            var prodLoja = SelecionePorIdProduto(produto);

            if (VerificarQuantidade(prodLoja, quantidadeVendida))
            {
                return false;
            }

            prodLoja.RetirarProdutoVendido(quantidadeVendida);
            return true;
        }

        public Loja SelecionePorIdProduto(Produto produto)
        {
            return listaDaLoja.FirstOrDefault(x => x.Produto.Id == produto.Id);
        }
          
        public Loja SelecionePorId(int id)
        {
            return listaDaLoja.FirstOrDefault(x => x.Id == id);
        }

        private bool ValidandoDuplicidade(Loja produtoEmLoja)
        {
            return listaDaLoja.Any(x => x.Produto == produtoEmLoja.Produto);
        }

        private bool VerificarQuantidade(Loja produtoNaLoja, decimal quantidadePedida)
        {
            if (produtoNaLoja.Quantidade < quantidadePedida)
            {
                Console.WriteLine($"Não existe quantidade suficiente.\n Temos {produtoNaLoja.Quantidade} unidade(s)!");
                return true;
            }

            return false;
        }
        public List<Loja> SelecionarTudo()
        {
            return listaDaLoja.OrderBy(x => x.Produto).ToList();
        }
    }
}
