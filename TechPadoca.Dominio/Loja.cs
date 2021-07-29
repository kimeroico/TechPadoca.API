using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPadoca.Dominio.Enum;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Loja : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal QuantidadeMinima { get; set; }
        public TipoQuantidadeEnum QtdTipo { get; set; }


        public void Cadastrar(int id, Produto produto, int quantidade, int quantidadeMinima, int qtdTipo)
        {
            Id = id;
            Produto = produto;
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
            QtdTipo = (TipoQuantidadeEnum)qtdTipo;
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