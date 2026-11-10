using Microsoft.Extensions.Configuration;
using Vendinha.Dados.Conexao;
using Npgsql;
using Vendinha.Dados.Repositorios;
using Vendinha.Negocio;

namespace Vendinha.Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IConfiguration configuracao = new ConfigurationBuilder()
                .AddUserSecrets<Vendinha.Desktop.Form1>()
                .Build();

            string? connectionString =
                configuracao.GetConnectionString("Vendinha");

            if(string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show("String de conexao nao encontrada");
                return;
                    
            }
            try
            {
                var conexao = new ConexaoPostgres(connectionString);
                using (var teste = conexao.ObterConexao())
                {
                    teste.Open();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                   $"Nao foi possivel conectar ao banco:\n{ex.Message}",
                   "Erro de conexao",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error); 

                return;
            }

           

            Application.Run(new Form1());
        }
    }
}