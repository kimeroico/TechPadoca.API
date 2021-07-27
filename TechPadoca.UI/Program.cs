using System;
using TechPadoca.Dominio;
using TechPadoca.Dados.Repositorio;

namespace TechPadoca.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            TesteAlan();
        }
        public static void TesteAlan()
        {
            ProdutoRepositorio produto = new ProdutoRepositorio();
            produto.Cadastrar("Pão", "Fabricado", "Fabricação Própria", 2, "Pãozinho quentinho", 50);

            Console.WriteLine("Cadastre um Produto no Estoque");
            Console.Write("Quantidade total: ");
            var qtdTotal = int.Parse(Console.ReadLine());
            Console.Write("Quantidade mínima: ");
            var qtdMinima = int.Parse(Console.ReadLine());
            Console.Write("Produto: ");
            var prod = produto.SelecionarPorId(int.Parse(Console.ReadLine()));
            Console.Write("Local: ");
            var local = Console.ReadLine();

            EstoqueRepositorio estoqueRepo = new EstoqueRepositorio();
            estoqueRepo.Cadastrar(qtdTotal, qtdMinima, prod, local);

            var resultado = estoqueRepo.SelecionarTudo();
            foreach (var i in resultado)
            {
                Console.WriteLine($"{i.QuantidadeMinima} | {i.Local} | {i.QuantidadeTotal} | {i.Produto}");
            }
        }
    }
 
}
