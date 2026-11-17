using System.Security.Cryptography.X509Certificates;
using Vendinha.Dados.Serviços;
using Vendinha.Desktop.Telinhas;

namespace Vendinha.Desktop
{
    public partial class Form1 : Form
    {
        private readonly ClienteSevice? service;
        private readonly DividaSevice? dividaService;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(ClienteSevice service) : this() { this.service = service; }
        public Form1(ClienteSevice service, DividaSevice dividaService) : this(service) { this.dividaService = dividaService; }

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

        private void btnCadastrarDivida_Click(object sender, EventArgs e)
        {
            if (service == null || dividaService == null) { return; }

            var tela = new CadastroDivida(service, dividaService);
            tela.ShowDialog(this);
        }

        private void btnListarDividas_Click(object sender, EventArgs e)
        {
            if (service == null || dividaService == null) { return; }

            var tela = new ListarDividas(service, dividaService);
            tela.ShowDialog(this);
        }
    }
}
