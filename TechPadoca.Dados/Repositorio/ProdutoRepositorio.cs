using System.Collections.Generic;
using System.Linq;
using TechPadoca.Dominio;

namespace TechPadoca.Dados.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>
    {
        public bool Incluir(string nome, string marca, decimal valorUnitario, string descricao)
        {
            Produto novoProduto = new Produto();
            novoProduto.Cadastrar(nome, marca, valorUnitario, descricao);

            if (Existe(novoProduto))
            {
                return false;
            }

            return base.Incluir(novoProduto);
        }

        public bool Alterar(int id, string nome, string marca, decimal valorUnitario, string descricao)
        {
            var prodAlterado = SelecionarPorId(id);

            prodAlterado.Alterar(nome, marca, valorUnitario, descricao);

            return base.Alterar(prodAlterado);
        }

        public void AlterarOff(int id)
        {
            var produto = SelecionarPorId(id);
            produto.Desligar();
            contexto.Produto.Update(produto);
            contexto.SaveChanges();
        }

        public void AlterarOn(int id)
        {
            var produto = SelecionarPorId(id);
            produto.Ligar();
            contexto.Produto.Update(produto);
            contexto.SaveChanges();
        }

        public bool Existe(Produto produto)
        {
            return contexto.Produto.Any(x => x.Nome.Trim().ToLower() == produto.Nome.Trim().ToLower()
            && x.Marca.Trim().ToLower() == produto.Marca.Trim().ToLower()
            && x.Descricao.Trim().ToLower() == produto.Descricao.Trim().ToLower());
        }

        public bool Existe(string nome, string marca, string descricao)
        {
            return contexto.Produto.Any(x => x.Nome.Trim().ToLower() == nome.Trim().ToLower()
            && x.Marca.Trim().ToLower() == marca.Trim().ToLower()
            && x.Descricao.Trim().ToLower() == descricao.Trim().ToLower());
        }
    }
}
