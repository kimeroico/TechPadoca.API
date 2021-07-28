using TechPadoca.Dominio.Enum;

namespace TechPadoca.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public CategoriaDeProdutoEnum Categoria { get; set; }
        public string Marca { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Descricao { get; set; }
        public decimal UnidadeDeMedida { get; set; }
        public bool Status { get; set; }

        public void Cadastrar(int id, string nome, int categoria, string marca, decimal valorUnitario, string descricao, decimal unidadeDeMedida)
        {
            Id = id;
            Nome = nome;
            Categoria = (CategoriaDeProdutoEnum) categoria;
            Marca = marca;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
            UnidadeDeMedida = unidadeDeMedida;
            Status = false;
        }

        public void Alterar(string nome, string marca, decimal valorUnitario, string descricao, decimal unidadeDeMedida)
        {
            Nome = nome;
            Marca = marca;
            ValorUnitario = valorUnitario;
            Descricao = descricao;
            UnidadeDeMedida = unidadeDeMedida;
        }

        public void AlterarStatus()
        {
            Status = !Status;
        }

        public override string ToString()
        {
            return $"{Nome} | {Marca} | {Categoria} | {ValorUnitario}" +
                      $" | {Descricao} | {UnidadeDeMedida} | {Status}";
        }
    }
}
