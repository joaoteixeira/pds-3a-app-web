using AppExemplo.Configs;

namespace AppExemplo.Models
{
    public class ProdutoDAO
    {

        private readonly Conexao _conexao;

        public ProdutoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }


        public List<Produto> ListarTodos()
        {
            var lista = new List<Produto>();

            var comando = _conexao.CreateCommand("SELECT * FROM produto");
            var leitor = comando.ExecuteReader();

            while(leitor.Read())
            {
                var produto = new Produto 
                { 
                    Id = leitor.GetInt32("id_pro"),
                    Nome = leitor.GetString("nome_pro"),
                    Descricao = leitor.GetString("descricao_pro"),
                    Quantidade = leitor.GetInt32("quantidade_pro"),
                    Preco = leitor.GetDecimal("preco_pro")
                };

                lista.Add(produto);
            }

            return lista;
        }

    }
}
