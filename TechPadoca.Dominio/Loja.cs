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
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal QuantidadeMinima { get; set; }
        public TipoQuantidadeEnum QtdTipo { get; set; }


        public void Cadastrar(int id, Produto produto, decimal quantidade, decimal quantidadeMinima, int qtdTipo)
        {
            Id = id;
            Produto = produto;
            Quantidade = quantidade;
            QuantidadeMinima = quantidadeMinima;
            QtdTipo = (TipoQuantidadeEnum)qtdTipo;
        }

        public void Alterar(decimal quantidade, decimal quantidadeMinima)
        {
            Quantidade = (quantidade < 0) || (quantidade < quantidadeMinima) ? Quantidade : quantidade;
            QuantidadeMinima = (quantidadeMinima < 0) ? QuantidadeMinima : quantidadeMinima;
        }

        public void AdicionarProduto(decimal quantidade)
        {
            if (quantidade > 0)
            {
                Quantidade += quantidade;
            }
        }

        public void RetirarProdutoVendido(decimal quantidade)
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