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

        /*
        public void Cadastrar(int id, int quantidadeTotal, int quantidadeMinima, Produto produto, string local)
        {
            Id = id;
            QuantidadeTotal = quantidadeTotal;
            QuantidadeMinima = quantidadeMinima;
            Produto = produto;
            Local = local;
        }

        public void Alterar(int quantidadeTotal, int quantidadeMinima, Produto produto, string local)
        {
            QuantidadeTotal = (quantidadeTotal <= 0) ? QuantidadeTotal : quantidadeTotal;
            QuantidadeMinima = quantidadeMinima;
            Produto = produto;
            Local = local;
        }

        public void VerificarFaltaProduto()
        {
            if (QuantidadeTotal <= QuantidadeMinima)
            {
                Console.WriteLine("Produto atingiu a quantidade mínima em estoque.");
            }
        }

        public void MandarParaLoja(int quantidade)
        {
            if (this.Produto.Categoria == "Revendido" || this.Produto.Categoria == "Fabricado")
            {
                if (this.QuantidadeTotal <= quantidade)
                {
                    if (this.QuantidadeTotal > 0)
                        QuantidadeTotal -= quantidade;
                    else
                      throw new DominioExcessao("Produto indisponível no estoque");
                }                
                //Mandar para a loja aqui? Ou na loja vai ter um metodo que recebe o produto em estoque?
            }
            VerificarFaltaProduto();
        }

        public void MandarIngrediente(int quantidade)
        {
            if (this.Produto.Categoria == "Ingrediente")
            {
                if (this.QuantidadeTotal <= quantidade)
                {
                    throw new DominioExcessao("A quantidade disponível em estoque é menor que a " +
                                             "quantidade pedida do ingrediente");
                }
                // mandar ingrediente para a receita??
            }
            VerificarFaltaProduto();
        }
        */
    }
}