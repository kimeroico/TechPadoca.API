using System.Collections.Generic;
using TechPadoca.Dominio;
using System.Linq;
using System;
using TechPadoca.Dominio.Enum;

namespace TechPadoca.Dados.Repositorio
{
    public class EstoqueRepositorio
    {
        private List<Estoque> listaEstoque { get; set; }

        public EstoqueRepositorio()
        {
            listaEstoque = new List<Estoque>();
        }
        public bool Cadastrar(decimal quantidadeTotal, decimal quantidadeMinima, Produto produto, string local, int qtdTipo)
        {
            var novoProdutoEstoque = new Estoque();
            novoProdutoEstoque.Cadastrar(listaEstoque.Count + 1, quantidadeTotal, quantidadeMinima, produto, local, qtdTipo);

            if (Existe(novoProdutoEstoque))
            {
                return false;
            }

            listaEstoque.Add(novoProdutoEstoque);

            return true;
        }

        public bool Alterar(int id, decimal quantidadeTotal, decimal quantidadeMinima, string local)
        {
            var produtoEmEstoque = SelecionarPorId(id);

            if (LocalEstaOcupado(local))
            {
                return false;
            }

            produtoEmEstoque.Alterar(quantidadeTotal, quantidadeMinima, local);
            return true;
           
        }

        public bool MandarParaLoja(decimal quantidade, Produto prodloja)
        {
            var produtoEmEstoque = SelecionarPorProdutoId(prodloja);

            if (VerificarQuantidade(produtoEmEstoque, quantidade) || VerificarCategoria(produtoEmEstoque))
            {
                return false;
            }
            
            produtoEmEstoque.MandarParaProduto(quantidade);
            return true;                                        
        }

        public bool MandarParaCozinha(decimal quantidade, Produto prodCozinha)
        {
            var produtoEmEstoque = SelecionarPorProdutoId(prodCozinha);

            if (VerificarQuantidade(produtoEmEstoque, quantidade) || !VerificarCategoria(produtoEmEstoque))
            {
                return false;
            }

            produtoEmEstoque.MandarParaProduto(quantidade);
            return true;
        }

        public bool VerificarQuantidade(Estoque produtoEmEstoque, decimal quantidadePedida)
        {
            if (produtoEmEstoque.QuantidadeTotal < quantidadePedida)
            {
                Console.WriteLine("Não existe quantidade suficiente.");
                return true;
            }

            return false;
        }

        public bool VerificarQuantidade(Produto produto, decimal quantidadePedida)
        {
            var produtoEmEstoque = SelecionarPorProdutoId(produto);

            if (produtoEmEstoque.QuantidadeTotal < quantidadePedida)
            {
                Console.WriteLine("Não existe quantidade suficiente.");
                return true;
            }

            return false;
        }

        private bool VerificarCategoria(Estoque produtoEmEstoque)
        {
            if (produtoEmEstoque.Produto.Categoria == CategoriaDeProdutoEnum.Ingrediente)
            {
                return true;
            }

            return false;
        }

        private bool Existe(Estoque estoque)
        {
            return listaEstoque.Any(x => x.Local.Trim().ToLower() == estoque.Local.Trim().ToLower()
            && x.Produto.Id == estoque.Produto.Id);
        }

        public Estoque SelecionarPorId(int id)
        {
            return listaEstoque.FirstOrDefault(x => x.Id == id);
        }

        public Estoque SelecionarPorProdutoId(Produto produto)
        {
            return listaEstoque.FirstOrDefault(x => x.Produto.Id == produto.Id);
        }

        private bool LocalEstaOcupado(string local)
        {
            return listaEstoque.Any(x => x.Local.Trim().ToLower() == local.Trim().ToLower());
        }

        public List<Estoque> SelecionarTudo()
        {
            return listaEstoque.OrderBy(x => x.Produto.Nome).ToList();
        }
    }
}
