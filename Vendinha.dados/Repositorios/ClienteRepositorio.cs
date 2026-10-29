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
    }
}
