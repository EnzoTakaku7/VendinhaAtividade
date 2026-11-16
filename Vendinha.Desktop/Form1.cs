using System.Security.Cryptography.X509Certificates;
using Vendinha.Dados.Serviços;
using Vendinha.Desktop.Telinhas;

namespace Vendinha.Desktop
{
    public partial class Form1 : Form
    {
        private readonly ClienteSevice? service;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(ClienteSevice service) : this() { this.service = service; }

        public void btnCadastro_Click(object sender, EventArgs e)
        {
            if (service == null) { MessageBox.Show("Serviço de cliente não disponível."); return; }

            var cadastro = new CadastroClientela(service);
            cadastro.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAbrirListagem_Click(object sender, EventArgs e)
        {
            if (service == null) { MessageBox.Show("Serviço de cliente não disponível."); return; }

            var listagem = new ListarClientela(service);
            listagem.ShowDialog(this);
        }
    }
}
