using Npgsql;

namespace Vendinha.Dados.Conexao
{
    public class ConexaoPostgres
    {
        private readonly NpgsqlDataSource dataSource;

        public ConexaoPostgres(string connectionString)
        {
            dataSource = NpgsqlDataSource.Create(connectionString);
        }
        public NpgsqlConnection ObterConexao()
        {
            return dataSource.CreateConnection();
        }
    }
}
