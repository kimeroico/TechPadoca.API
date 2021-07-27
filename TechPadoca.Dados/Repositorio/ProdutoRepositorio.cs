using System.Collections.Generic;
using System.Linq;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class ProdutoRepositorio
    {
        private List<Produto> listaProduto;

        public ProdutoRepositorio()
        {
            new List<Produto>();
        }

        public bool Cadastrar(string nome, string categoria, string marca, decimal valorUnitario, string descricao, decimal unidadeDeMedida)
        {
            Produto novoProduto = new Produto();
            novoProduto.Cadastrar(listaProduto.Count + 1, nome, categoria, marca, valorUnitario, descricao, unidadeDeMedida);

            if (Existe(novoProduto))
            {
                return false;
            }

            listaProduto.Add(novoProduto);
            return true;
        }

        public bool Alterar(int id, string nome, string categoria, string marca, decimal valorUnitario, string descricao, decimal unidadeDeMedida)
        {
            var prodAlterado = SelecionarPorId(id);

            if (AlterarExiste(nome, categoria, marca, descricao, unidadeDeMedida))
            {
                return false;
            }

            prodAlterado.Alterar(nome, categoria, marca, valorUnitario, descricao, unidadeDeMedida);
            return true;
        }

        public void AlterarStatus(int id)
        {
            var produto = SelecionarPorId(id);
            produto.AlterarStatus();
        }

        public Produto SelecionarPorId(int id)
        {
            return listaProduto.FirstOrDefault(x => x.Id == id);
        }

        public bool Existe(Produto produto)
        {
            return listaProduto.Any(x => x.Nome.Trim().ToLower() == produto.Nome.Trim().ToLower()
            && x.Categoria.Trim().ToLower() == produto.Categoria.Trim().ToLower()
            && x.Marca.Trim().ToLower() == produto.Marca.Trim().ToLower()
            && x.Descricao.Trim().ToLower() == produto.Descricao.Trim().ToLower()
            && x.UnidadeDeMedida == produto.UnidadeDeMedida);
        }

        public bool AlterarExiste(string nome, string categoria, string marca, string descricao, decimal unidadeDeMedida)
        {
            return listaProduto.Any(x => x.Nome.Trim().ToLower() == nome.Trim().ToLower()
            && x.Categoria.Trim().ToLower() == categoria.Trim().ToLower()
            && x.Marca.Trim().ToLower() == marca.Trim().ToLower()
            && x.Descricao.Trim().ToLower() == descricao.Trim().ToLower()
            && x.UnidadeDeMedida == unidadeDeMedida);
        }
    }
}
