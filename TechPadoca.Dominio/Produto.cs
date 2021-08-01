using System.Collections.Generic;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Produto : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }
        public Estoque Estoque { get; set; }
        public Loja Loja { get; set; }
        public List<ItemVenda> ItemVenda { get; set; }
        public List<Receita> Receita { get; set; }
        public List<Cozinha> Cozinha { get; set; }


        public void Cadastrar(string nome, string marca, decimal valorUnitario, string descricao)
        {
            Nome = nome;
            Marca = marca;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
            Status = false;
        }

        public void Alterar(string nome, string marca, decimal valorUnitario, string descricao)
        {
            Nome = nome;
            Marca = marca;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
        }

        public void Ligar()
        {
            Status = true;
        }

        public void Desligar()
        {
            Status = false;
        }


    }
}
