using System.Collections.Generic;
using TechPadoca.Dominio;
using System.Linq;
using System;

namespace TechPadoca.Dados.Repositorio
{
    public class EstoqueRepositorio
    {
        private List<Estoque> listaEstoque { get; set; }

        public EstoqueRepositorio()
        {
            listaEstoque = new List<Estoque>();
        }
        public void Cadastrar(int quantidadeTotal, int quantidadeMinima, Produto produto, string local)
        {
            //Esta deixando cadastrar um produto que ainda não existe, ver como tratar isso.

            Estoque novoProdutoEstoque = new Estoque();
            novoProdutoEstoque.Id = listaEstoque.Count + 1;
            novoProdutoEstoque.QuantidadeTotal = quantidadeTotal;
            novoProdutoEstoque.QuantidadeMinima = quantidadeMinima;
            novoProdutoEstoque.Produto = produto;
            novoProdutoEstoque.Local = local;

            if (Existe(novoProdutoEstoque))
               Console.WriteLine("Esse produto já existe no estoque");
            else
                listaEstoque.Add(novoProdutoEstoque);
        }

        public void Alterar(int id, int quantidadeTotal, int quantidadeMinima, string local)
        {
            Estoque produtoEmEstoque = SelecionarPorId(id);

            if (!Existe(produtoEmEstoque) || LocalEstaOcupado(local))
            {
               Console.WriteLine("Produto não existe ou Local do Estoque está ocupado");
            }
            else
            {
                produtoEmEstoque.QuantidadeTotal = (quantidadeTotal <= 0) ? produtoEmEstoque.QuantidadeTotal : quantidadeTotal;
                produtoEmEstoque.QuantidadeMinima = (quantidadeMinima <= 0) ? produtoEmEstoque.QuantidadeMinima : quantidadeMinima;
                produtoEmEstoque.Local = string.IsNullOrEmpty(local.Trim()) ? produtoEmEstoque.Local : local;
            }
        }

        public void MandarParaLoja(int id, int quantidade, LojaRepositorio listaLoja)
        {
            Estoque produtoEmEstoque = SelecionarPorId(id);

            if (produtoEmEstoque.Produto.Categoria == "Pronto".ToLower() || produtoEmEstoque.Produto.Categoria == "Fabricado".ToLower())
            {
                if (VerificarQuantidade(produtoEmEstoque, quantidade))
                {
                    // produto ou produto em estoque que vai pra loja?
                    // Dando erro de referencia no LojaRepositorio, null reference...
                    var prodId = produtoEmEstoque.Id;
                    listaLoja.ReceberProdutoDoEstoque(prodId, quantidade);
                }
                else
                    Console.WriteLine("Produto indisponível no estoque");
            }
            else
                Console.WriteLine("Produto não pode ser um ingrediente");
        }
        //public void MandarIngrediente(int id, int quantidade, ReceitaRepositorio listaReceita)
        //{
        //    Estoque produtoEmEstoque = SelecionarPorId(id);

        //    if (produtoEmEstoque.Produto.Categoria == "Ingrediente")
        //    {
        //        if (produtoEmEstoque.QuantidadeTotal <= quantidade)
        //            Console.WriteLine("A quantidade disponível em estoque é menor que a " +
        //                                     "quantidade pedida do ingrediente");
        //        else
        //        {
        //            var prodId = produtoEmEstoque.Produto.Id;
        //            listaReceita.ReceberIngredienteDoEstoque(prodId, quantidade);
        //        }
        //    }
        //}

        private bool VerificarQuantidade(Estoque produtoEmEstoque, int quantidadePedida)
        {
            if (produtoEmEstoque.QuantidadeTotal <= quantidadePedida)
            {
                if (produtoEmEstoque.QuantidadeTotal > 0)
                {
                    produtoEmEstoque.QuantidadeTotal -= quantidadePedida;
                    VerificarNecessidadeDeCompra(produtoEmEstoque);
                    return true;
                }
                else
                {
                    VerificarNecessidadeDeCompra(produtoEmEstoque);
                    return false;
                }
            }
            else
            {
                produtoEmEstoque.QuantidadeTotal -= quantidadePedida;
                VerificarNecessidadeDeCompra(produtoEmEstoque);
                return true;
            }

        }

        private bool Existe(Estoque estoque)
        {
            return listaEstoque.Any(x => x.Local.Trim().ToLower() == estoque.Local.Trim().ToLower()
            && x.Produto == estoque.Produto);
        }

        public Estoque SelecionarPorId(int id)
        {
            return listaEstoque.FirstOrDefault(x => x.Id == id);
        }

        private bool LocalEstaOcupado(string local)
        {
            return listaEstoque.Any(x => x.Local.Trim().ToLower() == local.Trim().ToLower());
        }

        public void VerificarNecessidadeDeCompra(Estoque produtoEstoque)
        {
            if (produtoEstoque.QuantidadeTotal <= produtoEstoque.QuantidadeMinima)
            {
                Console.WriteLine("Produto atingiu a quantidade mínima em estoque." +
                    "\nPor favor solicitar reposição ao setor de compras");
            }
        }
        public List<Estoque> SelecionarTudo()
        {
            return listaEstoque.OrderBy(x => x.Produto).ToList();
        }
    }
}
