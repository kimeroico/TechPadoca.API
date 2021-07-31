using System;
using System.Collections.Generic;
using System.Linq;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class LojaRepositorio : BaseRepositorio<Loja>
    {
        public bool Incluir(Produto produto, int quantidade, int quantidadeMinima)
        {
            var produtoLoja = new Loja();
            produtoLoja.Cadastrar(produto.Id, quantidade, quantidadeMinima);

            if (ValidandoDuplicidade(produtoLoja))
            {
                return false;
            }
            
            return base.Incluir(produtoLoja);
        }

        public bool Alterar(int id, int quantidade, int quantidadeMinima)
        {
            var objeto = SelecionarPorId(id);
            objeto.Alterar(quantidade, quantidadeMinima);
            return base.Alterar(objeto);
        }

        public void SolicitarProdutoDoEstoque(int id, int quantidadeSolicita)
        {
            var solicitado = SelecionarPorId(id);
            var estoque = new EstoqueRepositorio();
            var produtoRepo = new ProdutoRepositorio();
            var cozinha = new CozinhaRepositorio();
            var produto = produtoRepo.SelecionarPorId(solicitado.ProdutoId);

            if(produto.Marca != "Propria" && (estoque.MandarParaLoja(quantidadeSolicita, produto)))
            {
                solicitado.AdicionarProduto(quantidadeSolicita);
                contexto.Loja.Update(solicitado);
                contexto.SaveChanges();
                return;
            }

            cozinha.Incluir(solicitado.ProdutoId, quantidadeSolicita);
        }

        public void ReceberProdutoDaCozinha(int idProduto, int quantidade)
        {
            var loja = SelecionePorIdProduto(idProduto);
            loja.AdicionarProduto(quantidade);
            contexto.Loja.Update(loja);
            contexto.SaveChanges();
        }

        public bool ProdutoVendido(int id, int quantidadeVendida)
        {
            var solicitado = SelecionarPorId(id);

            if (VerificarQuantidade(solicitado, quantidadeVendida))
            {
                return false;
            }

            solicitado.RetirarProdutoVendido(quantidadeVendida);
            contexto.Loja.Update(solicitado);
            contexto.SaveChanges();
            return true;
        }

        public Loja SelecionePorIdProduto(int id)
        {
            return contexto.Loja.FirstOrDefault(x => x.ProdutoId == id);
        }

        private bool ValidandoDuplicidade(Loja produtoEmLoja)
        {
            return contexto.Loja.Any(x => x.Produto == produtoEmLoja.Produto);
        }

        private bool VerificarQuantidade(Loja produtoNaLoja, int quantidadePedida)
        {
            if (produtoNaLoja.Quantidade < quantidadePedida)
            {
                Console.WriteLine($"Não existe quantidade suficiente.\n Temos {produtoNaLoja.Quantidade} unidade(s)!");
                return true;
            }

            return false;
        }
        public override List<Loja> SelecionarTudo()
        {
            return base.SelecionarTudo().OrderBy(x => x.Produto).ToList();
        }
    }
}
