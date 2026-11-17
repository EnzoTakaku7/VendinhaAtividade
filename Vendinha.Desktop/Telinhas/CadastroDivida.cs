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
    public partial class CadastroDivida : Form
    {
        private readonly ClienteSevice? clienteSevice;
        private readonly DividaSevice? dividaService;

        public CadastroDivida()
        {
            InitializeComponent();
        }

        public CadastroDivida(ClienteSevice clienteSevice, DividaSevice dividaSevice) : this()
        {
            this.clienteSevice = clienteSevice;
            this.dividaService = dividaSevice;

            CarregarClientes();
        }

        public void CarregarClientes()
        {
            if (clienteSevice == null) { return; }
            try
            {
                var clientes = clienteSevice.Consultar();
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "NomeCompleto";
                cmbClientes.ValueMember = "Id";
                cmbClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os clientes:\n" + ex.Message);
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (dividaService == null) { return; }

            if (cmbClientes.SelectedItem is not Cliente cliente) { MessageBox.Show("Selecione um cliente."); return; }

            if (!decimal.TryParse(txtValor.Text, out decimal valor))
            {
                MessageBox.Show("Valor inválido.");
                return;
            }

            Divida divida = new Divida(cliente.Id, valor);

            try
            {
                if (dividaService.Criar(divida, out var erros))
                {
                    MessageBox.Show("Dívida cadastrada com sucesso.");
                    txtValor.Clear();
                    cmbClientes.SelectedIndex = -1;
                }
                else
                {
                    string mensagens = "";
                    foreach (var erro in erros)
                    {
                        mensagens += erro.ErrorMessage + "\n";
                    }
                    MessageBox.Show(mensagens);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao cadastrar a dívida:\n" + ex.Message);
            }
        }
    }
}
