using System;
using TechPadoca.Dominio.Enum;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Estoque : IEntity
    {
        public int Id { get; set; }
        public decimal QuantidadeTotal { get; set; }
        public decimal QuantidadeMinima { get; set; }
        public Produto Produto { get; set; }
        public string Local { get; set; }
        public TipoQuantidadeEnum QtdTipo { get; set; }

        public void Cadastrar(int id, decimal quantidadeTotal, decimal quantidadeMinima, Produto produto, string local, int qtdTpo)
        {
            Id = id;
            QuantidadeTotal = quantidadeTotal;
            QuantidadeMinima = quantidadeMinima;
            Produto = produto;
            Local = local;
            QtdTipo = (TipoQuantidadeEnum)qtdTpo;
        }

        public void Alterar(decimal quantidadeTotal, decimal quantidadeMinima, string local)
        {
            QuantidadeTotal = (quantidadeTotal < 0) ? QuantidadeTotal : quantidadeTotal;
            QuantidadeMinima = (quantidadeMinima < 0) ? QuantidadeMinima : quantidadeMinima;
            Local = string.IsNullOrEmpty(local.Trim()) ? Local : local;
        }

        public void MandarParaProduto(decimal quantidadeMandada)
        {
            QuantidadeTotal -= quantidadeMandada;
            NotificarNecessidadeDeCompra();
        }

        private bool NotificarNecessidadeDeCompra()
        {
            if (QuantidadeTotal <= QuantidadeMinima)
            {
                Console.WriteLine("É Necesseria Reposição do produto!");
                return true;
            }

            return false;
        }
    }
}