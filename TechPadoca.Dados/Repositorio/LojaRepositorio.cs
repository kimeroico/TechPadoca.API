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

        public bool Incluir(int id, int quantidade, int quantidadeMinima)
        {
            var produtoLoja = new Loja();
            produtoLoja.Cadastrar(listaDaLoja.Count + 1, /*id,*/ quantidade, quantidadeMinima);

            if (ValidandoDuplicidade(produtoLoja.Id))
            {
                return false;
            }

            listaDaLoja.Add(produtoLoja);
            return true;
        }

        public bool Alterar(int id, int quantidade, int quantidadeMinima)
        {
            var objeto = SelecionePorIdProduto(id);
            if (!ValidandoDuplicidade(objeto.Id))
            {
                return false;
            }

            objeto.Alterar(quantidade, quantidadeMinima);
            return true;
        }

        public void ReceberProdutoDoEstoque(int id, int quantidadeRecebida)
        {
            var produto = SelecionePorIdProduto(id);
            produto.AdicionarProduto(quantidadeRecebida);
        }

        public Loja SelecionePorIdProduto(int id)
        {
            return listaDaLoja.FirstOrDefault(x => x.Id == id);
        }

        public Loja SelecionePorId(int id)
        {
            return listaDaLoja.FirstOrDefault(x => x.Id == id);
        }

        private bool ValidandoDuplicidade(int id)
        {
            return listaDaLoja.Any(x => x.Id == id);
        }
    }
}
