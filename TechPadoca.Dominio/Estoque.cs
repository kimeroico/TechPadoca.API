using System;

namespace TechPadoca.Dominio
{
    public class Estoque
    {
        public int Id { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeMinima { get; set; }
        public Produto Produto { get; set; }
        public string Local { get; set; }

        public void Cadastrar(int id, int quantidadeTotal, int quantidadeMinima, Produto produto, string local)
        {
            Id = id;
            QuantidadeTotal = quantidadeTotal;
            QuantidadeMinima = quantidadeMinima;
            Produto = produto;
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