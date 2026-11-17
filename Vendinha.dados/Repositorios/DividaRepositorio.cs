using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Vendinha.Negocio;
using Vendinha.Dados.Conexao;

namespace Vendinha.Dados.Repositorios
{
    public class DividaRepositorio
    {
        private readonly ConexaoPostgres _conexaoPostgres;

        public DividaRepositorio(ConexaoPostgres conexaoPostgres)
        {
            this._conexaoPostgres = conexaoPostgres;
        }

        public void Cadastrar(Divida divida)
        {
            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"INSERT INTO divida (cliente_id, valor) VALUES (@clienteId, @valor);";

            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);

            comando.Parameters.AddWithValue("@clienteId", divida.ClienteId);
            comando.Parameters.AddWithValue("@valor", divida.Valor);
            comando.ExecuteNonQuery();
        }

        public List<Divida> ConsultarPorCliente(int clienteId)
        {
            var dividas = new List<Divida>();

            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"SELECT id, cliente_id, valor, paga, data_criacao, data_pagamento FROM divida WHERE cliente_id = @clienteId ORDER BY data_criacao DESC, id DESC;";
            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);

            comando.Parameters.AddWithValue("@clienteId", clienteId);
            using NpgsqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var divida = new Divida(
                    leitor.GetInt32(1),
                    leitor.GetDecimal(2)
                );

                divida.Id = leitor.GetInt32(0);
                divida.Paga = leitor.GetBoolean(3);
                divida.DataCriacao = leitor.GetDateTime(4);

                if (!leitor.IsDBNull(5))
                {
                    divida.DataPagamento = leitor.GetDateTime(5);
                }

                dividas.Add(divida);
            }

            return dividas;
        }


        public bool MarcarComoPaga(int dividaId, int clienteId)
        {
            using NpgsqlConnection conexao = _conexaoPostgres.ObterConexao();
            conexao.Open();

            string sql = @"UPDATE divida SET paga = TRUE, data_pagamento = CURRENT_TIMESTAMP WHERE id = @dividaId AND cliente_id = @clienteId AND paga = FALSE;";
            using NpgsqlCommand comando = new NpgsqlCommand(sql, conexao);

            comando.Parameters.AddWithValue("@dividaId", dividaId);
            comando.Parameters.AddWithValue("@clienteId", clienteId);

            int linhasAlteradas = comando.ExecuteNonQuery();

            return linhasAlteradas > 0;
        }


    }
}
