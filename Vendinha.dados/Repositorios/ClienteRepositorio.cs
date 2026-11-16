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
    }
}
