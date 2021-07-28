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
            var comando = "";
            var comando2 = "";
            ProdutoRepositorio produto = new ProdutoRepositorio();
            EstoqueRepositorio estoqueRepo = new EstoqueRepositorio();
            while (comando != "x")
            {                     
                Console.WriteLine("Cadastre um ou mais produtos");
                Console.Write("Nome: ");
                var nome = Console.ReadLine();
                Console.Write("Categoria: ");
                var categoria = Console.ReadLine();
                Console.Write("Marca: ");
                var marca = Console.ReadLine();
                Console.Write("Valor Unitário: ");
                var valorunit = decimal.Parse(Console.ReadLine());
                Console.Write("Descriçao: ");
                var descricao = Console.ReadLine();
                Console.Write("Unidade Medida: ");
                var unidademed = decimal.Parse(Console.ReadLine());

                produto.Cadastrar(nome, categoria, marca, valorunit,descricao, unidademed);
                Console.WriteLine();
                Console.WriteLine("Digite x para sair ou qualquer outro valor para continuar...");
                comando = Console.ReadLine();
            }
            Console.WriteLine();

            while (comando2 != "x")
            {
                Console.WriteLine("Cadastre um Produto no Estoque");
                Console.Write("Quantidade total: ");
                var qtdTotal = int.Parse(Console.ReadLine());
                Console.Write("Quantidade mínima: ");
                var qtdMinima = int.Parse(Console.ReadLine());
                Console.Write("Produto: ");
                var prod = produto.SelecionarPorId(int.Parse(Console.ReadLine()));
                Console.Write("Local: ");
                var local = Console.ReadLine();   
                
                estoqueRepo.Cadastrar(qtdTotal, qtdMinima, prod, local);
                Console.WriteLine();
                Console.WriteLine("Digite x para sair ou qualquer outro valor para continuar...");
                comando2 = Console.ReadLine();
            }
            Console.WriteLine();

            var resultado = estoqueRepo.SelecionarTudo();
            foreach (var i in resultado)
            {
                Console.WriteLine($"Quantidade mínima: {i.QuantidadeMinima}\nLocal: {i.Local}\nQuantidade total: {i.QuantidadeTotal}\nProduto: {i.Produto}");
            }

            Console.WriteLine("Deseja alterar um produto em estoque? (s/n)");
            var alterar = Console.ReadLine();
            if (alterar == "s")
            {
                Console.WriteLine("Qual o Id do produto em Estoque que vai alterar?");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine("nova qtdd total: ");
                var qtdtotal = int.Parse(Console.ReadLine());
                Console.WriteLine("nova qtdd Mínima: ");
                var qtdminima = int.Parse(Console.ReadLine());
                Console.WriteLine("novo local: ");
                var local = Console.ReadLine();
                estoqueRepo.Alterar(id, qtdtotal, qtdminima, local);
                Console.WriteLine();
                var resultado3 = estoqueRepo.SelecionarTudo();
                foreach (var i in resultado3)
                {
                    Console.WriteLine("Após alteração:    ");
                    Console.WriteLine($"Quantidade mínima: {i.QuantidadeMinima}\nLocal: {i.Local}\nQuantidade total: {i.QuantidadeTotal}\nProduto: {i.Produto}");
                }
            }

            //Console.WriteLine("Deseja enviar um produto em estoque para a loja? (s/n)");
            //var enviar = Console.ReadLine();
            //if (enviar == "s")
            //{
            //    Console.WriteLine("Qual o Id do produto que vai para a loja?");
            //    var id = int.Parse(Console.ReadLine());
            //    Console.WriteLine("Quantidade do produto pra loja: ");
            //    var qtd = int.Parse(Console.ReadLine());
            //    LojaRepositorio loja = new LojaRepositorio();

            //    estoqueRepo.MandarParaLoja(qtd, loja);
            //    Console.WriteLine(loja); //???
            //}
        }
    }
 
}
