using System.Collections.Generic;
using TechPadoca.Dominio;
using System.Linq;
using System;

namespace TechPadoca.Dados.Repositorio
{
    public class EstoqueRepositorio : BaseRepositorio<Estoque>
    {
        public bool Incluir(int quantidadeTotal, int quantidadeMinima, Produto produto, string local)
        {
            var novoProdutoEstoque = new Estoque();
            novoProdutoEstoque.Cadastrar(quantidadeTotal, quantidadeMinima, produto.Id, local);

            if (Existe(novoProdutoEstoque))
            {
                return false;
            }

            return base.Incluir(novoProdutoEstoque);
        }

        public bool Alterar(int id, int quantidadeTotal, int quantidadeMinima, string local)
        {
            var produtoEmEstoque = SelecionarPorId(id);

            produtoEmEstoque.Alterar(quantidadeTotal, quantidadeMinima, local);

            return base.Alterar(produtoEmEstoque);
           
        }

        public bool MandarParaLoja(int quantidade, Produto prodloja)
        {
            var produtoEmEstoque = SelecionarPorProdutoId(prodloja);

            if (VerificarQuantidade(produtoEmEstoque, quantidade))
            {
                return false;
            }
            
            produtoEmEstoque.MandarParaProduto(quantidade);
            contexto.Estoque.Update(produtoEmEstoque);
            contexto.SaveChanges();
            return true;                                        
        }

        //public bool MandarParaCozinha(decimal quantidade, Produto prodCozinha)
        //{
        //    var produtoEmEstoque = SelecionarPorProdutoId(prodCozinha);

        //    if (VerificarQuantidade(produtoEmEstoque, quantidade) || !VerificarCategoria(produtoEmEstoque))
        //    {
        //        return false;
        //    }

        //    produtoEmEstoque.MandarParaProduto(quantidade);
        //    return true;
        //}

        public bool VerificarQuantidade(Estoque produtoEmEstoque, int quantidadePedida)
        {
            if (produtoEmEstoque.QuantidadeTotal < quantidadePedida)
            {
                Console.WriteLine("Não existe quantidade suficiente.");
                return true;
            }

            return false;
        }

        //public bool VerificarQuantidade(Produto produto, int quantidadePedida)
        //{
        //    var produtoEmEstoque = SelecionarPorProdutoId(produto);

        //    if (produtoEmEstoque.QuantidadeTotal < quantidadePedida)
        //    {
        //        Console.WriteLine("Não existe quantidade suficiente.");
        //        return true;
        //    }

        //    return false;
        //}

        private bool Existe(Estoque estoque)
        {
            return contexto.Estoque.Any(x => x.Local.Trim().ToLower() == estoque.Local.Trim().ToLower()
            && x.Produto.Id == estoque.Produto.Id);
        }

        public Estoque SelecionarPorProdutoId(Produto produto)
        {
            return contexto.Estoque.FirstOrDefault(x => x.Produto.Id == produto.Id);
        }

        //private bool LocalEstaOcupado(string local)
        //{
        //    return contexto.Estoque.Any(x => x.Local.Trim().ToLower() == local.Trim().ToLower());
        //}

        public override List<Estoque> SelecionarTudo()
        {
            return base.SelecionarTudo().OrderBy(x => x.Id).ToList();
        }
    }
}
