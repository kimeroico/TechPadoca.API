using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio.Enum;

namespace TechPadoca.Dominio
{
    public class Loja
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }


        public void Cadastrar(int id, Produto produto, int quantidade, int quantidadeMinima)
        {
            Id = id;
            Produto = produto;
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