using TechPadoca.Dominio.Enum;
using TechPadoca.Dominio.Interface;

namespace TechPadoca.Dominio
{
    public class Produto : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public CategoriaDeProdutoEnum Categoria { get; set; }
        public string Marca { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Descricao { get; set; }
        public TipoQuantidadeEnum QtdTipo { get; set; }
        public bool Status { get; set; }
        public Cozinha Cozinha { get; set; }
        public Estoque Estoque { get; set; }

        public void Cadastrar(int id, string nome, int categoria, string marca, decimal valorUnitario, string descricao, int qtdTipo)
        {
            Id = id;
            Nome = nome;
            Categoria = (CategoriaDeProdutoEnum) categoria;
            Marca = marca;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
            QtdTipo = (TipoQuantidadeEnum)qtdTipo;
            Status = false;
        }

        public void Alterar(string nome, string marca, decimal valorUnitario, string descricao)
        {
            Nome = nome;
            Marca = marca;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
        }

        public void AlterarStatus()
        {
            Status = !Status;
        }
    }
}
