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
            dgvClientes.ClearSelection();
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


        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (sevice == null) { return; }

            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para editar.");
                return;
            }

            try
            {
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colId"].Value);

                var clientes = sevice.Consultar();
                var cliente = clientes.Find(c => c.Id == clienteId);

                if (cliente == null)
                {
                    MessageBox.Show("Cliente não encontrado.");
                    return;
                }

                var tela = new EditarClientela(sevice, cliente);

                if (tela.ShowDialog(this) == DialogResult.OK) { CarregarDados(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao abrir a edição:\n" + ex.Message);
            }
        }


        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            if (sevice == null) { return; }

            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cliente para excluir.");
                return;
            }

            int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colId"].Value);
            var resposta = MessageBox.Show("Deseja realmente excluir este cliente?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes) { return; }

            try
            {
                if (sevice.Excluir(clienteId, out var erros))
                {
                    MessageBox.Show("Cliente excluído com sucesso!");
                    CarregarDados();
                }
                else
                {
                    string mensagens = "";
                    foreach (var erro in erros) { mensagens += erro.ErrorMessage + "\n"; }
                    MessageBox.Show(mensagens);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao excluir o cliente:\n" + ex.Message);
            }
        }

    }
}
