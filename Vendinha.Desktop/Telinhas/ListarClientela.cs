using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendinha.Negocio;
using Vendinha.Dados.Serviços;

namespace Vendinha.Desktop.Telinhas
{
    public partial class ListarClientela : Form
    {
        private readonly ClienteSevice? sevice;
        private int paginaAtual = 1;
        private const int quantidadePorPagina = 10;

        public ListarClientela()
        {
            InitializeComponent();

        }

        private void CarregarDados()
        {
            if (sevice == null) { return; }

            try
            {
                string pesquisa = txtPesquisa.Text.Trim();
                int totalClientes = sevice.ContarClientes(pesquisa);
                int totalPaginas = (totalClientes + quantidadePorPagina - 1) / quantidadePorPagina;

                if (totalPaginas == 0)
                {
                    totalPaginas = 1;
                }

                if (paginaAtual > totalPaginas)
                {
                    paginaAtual = totalPaginas;
                }

                var clientes = sevice.ConsultarPaginando(pesquisa, paginaAtual);

                CarregarDadosTabela(clientes);
                lblPagina.Text = "Página " + paginaAtual + " de " + totalPaginas;
                btnAnterior.Enabled = paginaAtual > 1;
                btnProximo.Enabled = paginaAtual < totalPaginas;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os dados:\n" + ex.Message);
            }

        }

        private void CarregarDadosTabela(List<Cliente> lista)
        {
            dgvClientes.Rows.Clear();
            foreach (var cliente in lista)
            {
                dgvClientes.Rows.Add(cliente.Id, cliente.NomeCompleto, cliente.CPF, cliente.DataNascimento.ToString("dd/MM/yyyy"), cliente.Idade, cliente.Email);
            }
        }
        public ListarClientela(ClienteSevice sevice) : this()
        {
            this.sevice = sevice;
            CarregarDados();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            paginaAtual = 1;
            CarregarDados();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            paginaAtual++;
            CarregarDados();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            paginaAtual--;
            CarregarDados();
        }
    }
}
