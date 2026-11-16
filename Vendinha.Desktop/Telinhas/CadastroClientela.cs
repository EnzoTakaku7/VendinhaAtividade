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
    public partial class CadastroClientela : Form
    {
        private readonly ClienteSevice? service;

        public CadastroClientela()
        {
            InitializeComponent();
            DTPNascimento.MaxDate = DateTime.Today;
        }

        public CadastroClientela(ClienteSevice service) : this() { this.service = service; }

        private void CadastroClientela_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (service == null) { MessageBox.Show("Serviço não inicializado."); return; }

            var cliente = new Cliente
                (
                    txtNome.Text.Trim(),
                    txtCPF.Text.Trim(),
                    DTPNascimento.Value.Date
                );

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                cliente.Email = txtEmail.Text.Trim();
            }
            
            try
            {
                var sucesso = service.Criar(cliente, out var erros);
                
                if (sucesso) { MessageBox.Show("Cliente cadastrado com sucesso"); this.Close(); }

                else
                {
                    string mensagem = "";

                    foreach (var erro in erros)
                    {
                        mensagem += erro.ErrorMessage + "\n";
                    }
                    MessageBox.Show(mensagem, "Erros de validação");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao cadastrar o cliente:\n" + ex.Message);
            }
        }
    }
}
