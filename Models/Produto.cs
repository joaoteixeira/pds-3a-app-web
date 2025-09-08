namespace AppExemplo.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public string? Descricao { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco {  get; set; }
    }
}
