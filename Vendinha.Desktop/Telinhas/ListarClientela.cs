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
        public ListarClientela()
        {
            InitializeComponent();

        }

        private void CarregarDados()
        {
            if (sevice == null) { return; }

            try
            {
                var clientes = sevice.Consultar();
                CarregarDadosTabela(clientes);

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
            if (sevice == null) { return; }
            
            try { var resultado = sevice.Consultar(txtPesquisa.Text.Trim()); CarregarDadosTabela(resultado); }
            catch (Exception ex) { MessageBox.Show("Ocorreu um erro ao pesquisar os dados:\n" + ex.Message); }


        }
    }
}
