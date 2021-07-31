using System;
using TechPadoca.Dominio;
using TechPadoca.Dados.Repositorio;

namespace TechPadoca.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testes();
        }
        //public static void Testes()
        //{
        //    var comando = "";
        //    var comando2 = "";
        //    var comando3 = "";
        //    var comando4 = "";
        //    var produtoRepo = new ProdutoRepositorio();
        //    var estoqueRepo = new EstoqueRepositorio();
        //    var vendaRepo = new VendaRepositorio();
        //    var itemRepo = new ItemVendaRepositorio();
        //    var lojaRepo = new LojaRepositorio();

        //    while (comando != "x")
        //    {                     
        //        Console.WriteLine("Cadastre um ou mais produtos");
        //        Console.Write("Nome: ");
        //        var nome = Console.ReadLine();
        //        Console.Write("Categoria: ");
        //        var categoria = int.Parse(Console.ReadLine());
        //        Console.Write("Marca: ");
        //        var marca = Console.ReadLine();
        //        Console.Write("Valor Unitário: ");
        //        var valorunit = decimal.Parse(Console.ReadLine());
        //        Console.Write("Descriçao: ");
        //        var descricao = Console.ReadLine();
        //        Console.Write("Unidade Medida: ");
        //        var unidademed = int.Parse(Console.ReadLine());

        //        produtoRepo.Cadastrar(nome, categoria, marca, valorunit,descricao, unidademed);
        //        Console.WriteLine();
        //        Console.WriteLine("Digite x para sair ou qualquer outro valor para continuar...");
        //        comando = Console.ReadLine();
        //    }
        //    Console.WriteLine();

        //    //while (comando2 != "x")
        //    //{
        //    //    Console.WriteLine("Cadastre um Produto no Estoque");
        //    //    Console.Write("Quantidade total: ");
        //    //    var qtdTotal = int.Parse(Console.ReadLine());
        //    //    Console.Write("Quantidade mínima: ");
        //    //    var qtdMinima = int.Parse(Console.ReadLine());
        //    //    Console.Write("Produto: ");
        //    //    var prod = produtoRepo.SelecionarPorId(int.Parse(Console.ReadLine()));
        //    //    Console.Write("Local: ");
        //    //    var local = Console.ReadLine();
        //    //    Console.Write("Quantidade Tipo: ");
        //    //    var qtdTipo = int.Parse(Console.ReadLine());
        //    //    estoqueRepo.Cadastrar(qtdTotal, qtdMinima, prod, local, qtdTipo);
        //    //    Console.WriteLine();
        //    //    Console.WriteLine("Digite x para sair ou qualquer outro valor para continuar...");
        //    //    comando2 = Console.ReadLine();
        //    //}
        //    Console.WriteLine();

        //    //var resultado = estoqueRepo.SelecionarTudo();
        //    //foreach (var i in resultado)
        //    //{
        //    //    Console.WriteLine($"Quantidade mínima: {i.QuantidadeMinima}\nLocal: {i.Local}\nQuantidade total: {i.QuantidadeTotal}"+
        //    //        $"\nProduto: {i.Produto.Nome} | Marcar: {i.Produto.Marca} | Categoria: {i.Produto.Categoria} | Descrição: {i.Produto.Descricao}"+
        //    //        $" | status: {i.Produto.Status}");
        //    //}

        //    //Console.WriteLine("Deseja alterar um produto em estoque? (s/n)");
        //    //var alterar = Console.ReadLine();
        //    //if (alterar == "s")
        //    //{
        //    //    Console.WriteLine("Qual o Id do produto em Estoque que vai alterar?");
        //    //    var id = int.Parse(Console.ReadLine());
        //    //    Console.WriteLine("nova qtdd total: ");
        //    //    var qtdtotal = int.Parse(Console.ReadLine());
        //    //    Console.WriteLine("nova qtdd Mínima: ");
        //    //    var qtdminima = int.Parse(Console.ReadLine());
        //    //    Console.WriteLine("novo local: ");
        //    //    var local = Console.ReadLine();
        //    //    estoqueRepo.Alterar(id, qtdtotal, qtdminima, local);
        //    //    Console.WriteLine();
        //    //    var resultado3 = estoqueRepo.SelecionarTudo();
        //    //    foreach (var i in resultado3)
        //    //    {
        //    //        Console.WriteLine("Após alteração:    ");
        //    //        Console.WriteLine($"Quantidade mínima: {i.QuantidadeMinima}\nLocal: {i.Local}\nQuantidade total: {i.QuantidadeTotal}\nProduto: {i.Produto}");
        //    //    }
        //    //}

        //    //Console.WriteLine("Deseja enviar um produto em estoque para a loja? (s/n)");
        //    //var enviarLoja = Console.ReadLine();
        //    //if (enviarLoja == "s")
        //    //{
        //    //    Console.WriteLine("Qual o produto que vai para a loja?");
        //    //    var prod = produtoRepo.SelecionarPorId(int.Parse(Console.ReadLine()));
        //    //    Console.WriteLine("Quantidade do produto pra loja: ");
        //    //    var qtd = int.Parse(Console.ReadLine());
        //    //    LojaRepositorio loja = new LojaRepositorio();
        //    //    estoqueRepo.MandarParaLoja(qtd, prod);
        //    //    Console.WriteLine(loja);
        //    //    Console.WriteLine();
        //    //}

        //    //Console.WriteLine("Deseja enviar um produto em estoque para a Cozinha? (s/n)");
        //    //var enviarCozinha = Console.ReadLine();
        //    //if (enviarCozinha == "s")
        //    //{
        //    //    Console.WriteLine("Qual o produto que vai para a Cozinha?");
        //    //    var prod = produtoRepo.SelecionarPorId(int.Parse(Console.ReadLine()));
        //    //    Console.WriteLine("Quantidade do produto pra Cozinha: ");
        //    //    var qtd = int.Parse(Console.ReadLine());
        //    //    CozinhaRepositorio cozinha = new CozinhaRepositorio();
        //    //    estoqueRepo.MandarParaCozinha(qtd, prod);
        //    //    Console.WriteLine(cozinha);
        //    //    Console.WriteLine();
        //    //}

        //    Console.WriteLine("Cadastre uma ou mais vendas");
        //    while (comando2 != "x")
        //    {
        //        Console.Write("Produto: ");
        //        var prod = produtoRepo.SelecionarPorId(int.Parse(Console.ReadLine()));
        //        Console.WriteLine("Quantidade: ");
        //        var qtd = decimal.Parse(Console.ReadLine());
        //        Console.WriteLine("nova qtdd Mínima: ");
        //        var qtdminima = decimal.Parse(Console.ReadLine());
        //        Console.Write("Quantidade Tipo: ");
        //        var qtdTipo = int.Parse(Console.ReadLine());
        //        lojaRepo.Incluir(prod, qtd, qtdminima, qtdTipo);
        //        Console.WriteLine();
        //        Console.WriteLine("Digite x para sair ou qualquer outro valor para continuar...");
        //        comando2 = Console.ReadLine();

        //    }

        //    Console.WriteLine("Cadastre uma ou mais vendas");
        //    while (comando3 != "x")
        //    {
        //        Console.WriteLine("Desconto: ");
        //        var desconto = decimal.Parse(Console.ReadLine());
        //        vendaRepo.Cadastrar(desconto);
        //        Console.WriteLine("Digite x para sair ou qualquer outro valor para continuar...");
        //        comando3 = Console.ReadLine();
        //        Console.WriteLine();
        //    }

        //    Console.WriteLine("Cadastre o(s) items de venda");
        //    while (comando4 != "x")
        //    {
        //        Console.Write("Produto: ");
        //        var prod = produtoRepo.SelecionarPorId(int.Parse(Console.ReadLine()));
        //        Console.Write("Venda: ");
        //        var venda = vendaRepo.SelecionarPorId(int.Parse(Console.ReadLine()));
        //        Console.WriteLine("Quantidade: ");
        //        var qtd = decimal.Parse(Console.ReadLine());
        //        itemRepo.Incluir(prod, venda, qtd);
        //        Console.WriteLine();
        //        Console.WriteLine("Digite x para sair ou qualquer outro valor para continuar...");
        //        comando3 = Console.ReadLine();
        //        Console.WriteLine();
        //    }
        //    var itensDaVenda = itemRepo.SelecionarTudo();
        //    foreach (var i in itensDaVenda)
        //    {
        //        Console.WriteLine("Itens da venda:  ");
        //        Console.WriteLine($"Produto: {i.Produto}\nVenda: {i.Venda}\nQuantidade: {i.Quantidade}\nValor Unitario: {i.ValorUnitario}\n");
        //    }


        //}
    }
 
}
