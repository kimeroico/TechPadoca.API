using System;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Loja : IEntity
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
   
        public void Cadastrar(int idProduto, int quantidade, int quantidadeMinima)
        {
            ProdutoId = idProduto;
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
        }

        public void Alterar(int quantidade, int quantidadeMinima)
        {
            Quantidade = (quantidade < 0) || (quantidade < quantidadeMinima) ? Quantidade : quantidade;
            QuantidadeMinima = (quantidadeMinima < 0) ? QuantidadeMinima : quantidadeMinima;
        }

        public void AdicionarProduto(int quantidade)
        {
            if (quantidade > 0)
            {
                Quantidade += quantidade;
            }
        }

        public void RetirarProdutoVendido(int quantidade)
        {
            Quantidade -= quantidade;
            NotificarNecessidadeDeReposicao();
        }

        private bool NotificarNecessidadeDeReposicao()
        {
            if (Quantidade <= QuantidadeMinima)
            {
                Console.WriteLine("É Necesseria Reposição do produto!");
                return true;
            }

            return false;
        }
    }
}