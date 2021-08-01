using System;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Estoque : IEntity
    {
        public int Id { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeMinima { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public string Local { get; set; }

        public void Cadastrar(int quantidadeTotal, int quantidadeMinima, int idProduto, string local)
        {
            QuantidadeTotal = quantidadeTotal;
            QuantidadeMinima = quantidadeMinima;
            IdProduto = idProduto;
            Local = local;
        }

        public void Alterar(int quantidadeTotal, int quantidadeMinima, string local)
        {
            QuantidadeTotal = (quantidadeTotal < 0) ? QuantidadeTotal : quantidadeTotal;
            QuantidadeMinima = (quantidadeMinima < 0) ? QuantidadeMinima : quantidadeMinima;
            Local = string.IsNullOrEmpty(local.Trim()) ? Local : local;
        }

        public void MandarParaProduto(int quantidadeMandada)
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