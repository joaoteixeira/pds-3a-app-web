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

        public void Inserir(Produto produto)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO produto VALUES (null, null, @_nome, @_descricao, @_qtd, @_preco)");

                comando.Parameters.AddWithValue("@_nome", produto.Nome);
                comando.Parameters.AddWithValue("@_descricao", produto.Descricao);
                comando.Parameters.AddWithValue("@_qtd", produto.Quantidade);
                comando.Parameters.AddWithValue("@_preco", produto.Preco);

                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
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
                    Descricao = leitor.IsDBNull(leitor.GetOrdinal("descricao_pro")) ? "" : leitor.GetString("descricao_pro"),
                    Quantidade = leitor.GetInt32("quantidade_pro"),
                    Preco = leitor.GetDecimal("preco_pro")
                };

                lista.Add(produto);
            }

            return lista;
        }

    }
}
