using System.Collections.Generic;
using System.Linq;
using TechPadoca.Dominio;
using TechPadoca.Dominio.Enum;

namespace TechPadoca.Dados.Repositorio
{
    public class ProdutoRepositorio
    {
        private List<Produto> listaProduto;

        public ProdutoRepositorio()
        {
           listaProduto = new List<Produto>();
        }

        public bool Cadastrar(string nome, int categoria, string marca, decimal valorUnitario, string descricao, int qtdTipo)
        {
            Produto novoProduto = new Produto();
            novoProduto.Cadastrar(listaProduto.Count + 1, nome, categoria, marca, valorUnitario, descricao, qtdTipo);

            if (Existe(novoProduto))
            {
                return false;
            }

            listaProduto.Add(novoProduto);
            return true;
        }

        public bool Alterar(int id, string nome, string marca, decimal valorUnitario, string descricao)
        {
            var prodAlterado = SelecionarPorId(id);

            if (Existe(nome, marca, descricao))
            {
                return false;
            }

            prodAlterado.Alterar(nome, marca, valorUnitario, descricao);
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
            && x.Marca.Trim().ToLower() == produto.Marca.Trim().ToLower()
            && x.Descricao.Trim().ToLower() == produto.Descricao.Trim().ToLower());
        }

        public bool Existe(string nome, string marca, string descricao)
        {
            return listaProduto.Any(x => x.Nome.Trim().ToLower() == nome.Trim().ToLower()
            && x.Marca.Trim().ToLower() == marca.Trim().ToLower()
            && x.Descricao.Trim().ToLower() == descricao.Trim().ToLower());
        }
    }
}
