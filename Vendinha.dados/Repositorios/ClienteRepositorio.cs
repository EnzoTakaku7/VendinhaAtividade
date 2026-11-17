using Npgsql;
using Vendinha.Negocio;
using Vendinha.Dados.Conexao;

namespace Vendinha.Dados.Repositorios
{
    public class ClienteRepositorio
    {
        private readonly ConexaoPostgres _conexaoPostgres;

        public ClienteRepositorio(ConexaoPostgres conexaoPostgres)
        {
            _conexaoPostgres = conexaoPostgres;
        }

        public void Cadastrar(Cliente cliente)
        {
            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"
                INSERT INTO cliente
                    (nome_completo, cpf, data_nascimento, email)
                VALUES
                    (@nome, @cpf, @nascimento, @email);
            ";

            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);

            comando.Parameters.AddWithValue("@nome", cliente.NomeCompleto);
            comando.Parameters.AddWithValue("@cpf", cliente.CPF);
            comando.Parameters.AddWithValue("@nascimento", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@email", (object?)cliente.Email ?? DBNull.Value);

        comando.ExecuteNonQuery();
        }

        public List<Cliente> Consultar() {
            
            var resultado = new List<Cliente>();

            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"SELECT id, nome_completo, cpf, data_nascimento, email FROM cliente ORDER BY nome_completo";
            
            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);
            using NpgsqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente(
                    leitor.GetString(1),
                    leitor.GetString(2),
                    leitor.GetDateTime(3)
                );
                cliente.Id = leitor.GetInt32(0);
                
                if (!leitor.IsDBNull(4))
                {
                    cliente.Email = leitor.GetString(4);
                }
                resultado.Add(cliente);
            }

            return resultado;    
        }


        public List<Cliente> ConsultarPaginado(string pesquisa, int pagina)
        {
            var resultado = new List<Cliente>();

            if (pagina < 1) { pagina = 1; }
            int offset = (pagina - 1) * 10;

            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"
            SELECT c.id, c.nome_completo, c.cpf, c.data_nascimento, c.email,
            COALESCE(SUM(d.valor), 0) AS total_divida_aberta
            FROM cliente c
            LEFT JOIN divida d ON d.cliente_id = c.id AND d.paga = FALSE
            WHERE POSITION(LOWER(@pesquisa) IN LOWER(c.nome_completo)) > 0
            GROUP BY c.id
            ORDER BY total_divida_aberta DESC, c.nome_completo, c.id
            LIMIT 10 OFFSET @offset";

            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@pesquisa", pesquisa ?? "");
            comando.Parameters.AddWithValue("@offset", offset);
            using NpgsqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente(leitor.GetString(1), leitor.GetString(2), leitor.GetDateTime(3));
                cliente.Id = leitor.GetInt32(0);

                if (!leitor.IsDBNull(4)) { cliente.Email = leitor.GetString(4); }

                cliente.TotalDividaAberta = leitor.GetDecimal(5);
                resultado.Add(cliente);
            }

            return resultado;
        }
        public int ContarClientes(string pesquisa)
        {
            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"SELECT COUNT(*) FROM cliente WHERE POSITION(LOWER(@pesquisa) IN LOWER(nome_completo)) > 0";

            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);

            comando.Parameters.AddWithValue("@pesquisa", pesquisa ?? "");
            
            return Convert.ToInt32(comando.ExecuteScalar());
        }


        public bool Atualizar(Cliente cliente)
        {
            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"UPDATE cliente SET nome_completo = @nome, cpf = @cpf, data_nascimento = @nascimento, email = @email WHERE id = @id";

            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);

            comando.Parameters.AddWithValue("@id", cliente.Id);
            comando.Parameters.AddWithValue("@nome", cliente.NomeCompleto);
            comando.Parameters.AddWithValue("@cpf", cliente.CPF);
            comando.Parameters.AddWithValue("@nascimento", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@email", (object?)cliente.Email ?? DBNull.Value);

            return comando.ExecuteNonQuery() > 0;
        }

        public bool Excluir(int clienteId)
        {
            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"DELETE FROM cliente WHERE id = @id";

            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@id", clienteId);

            return comando.ExecuteNonQuery() > 0;
        }


    }
}
