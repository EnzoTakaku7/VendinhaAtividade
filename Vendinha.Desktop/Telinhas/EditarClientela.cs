using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendinha.Dados.Serviços;
using Vendinha.Negocio;

namespace Vendinha.Desktop.Telinhas
{
    public partial class EditarClientela : Form
    {
        private readonly ClienteSevice? service;
        private int clienteId;

        public EditarClientela()
        {
            InitializeComponent();
        }

        public EditarClientela(ClienteSevice service, Cliente cliente) : this()
        {
            this.service = service;
            this.clienteId = cliente.Id;

            txtNome.Text = cliente.NomeCompleto;
            txtCPF.Text = cliente.CPF;
            dtpNascimento.Value = cliente.DataNascimento;
            txtEmail.Text = cliente.Email ?? "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (service == null) { return; }

            var cliente = new Cliente(txtNome.Text.Trim(), txtCPF.Text.Trim(), dtpNascimento.Value.Date);
            cliente.Id = clienteId;
            cliente.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();

            try
            {
                if (service.Atualizar(cliente, out var erros))
                {
                    MessageBox.Show("Cliente atualizado com sucesso!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
                MessageBox.Show("Ocorreu um erro ao atualizar o cliente:\n" + ex.Message);
            }
        }
    }
}
