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
    public partial class ListarDividas : Form
    {
        private readonly ClienteSevice? clienteSevice;
        private readonly DividaSevice? dividaService;

        public ListarDividas()
        {
            InitializeComponent();
        }
        public ListarDividas(
           ClienteSevice clienteSevice,
           DividaSevice dividaService) : this()
        {
            this.clienteSevice = clienteSevice;
            this.dividaService = dividaService;

            CarregarClientes();
        }

        private void CarregarClientes()
        {
            if (clienteSevice == null) { return; }

            try
            {
                var clientes = clienteSevice.Consultar();

                cmbClientes.DisplayMember = "NomeCompleto";
                cmbClientes.ValueMember = "Id";
                cmbClientes.DataSource = clientes;
                cmbClientes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar clientes:\n" + ex.Message
                );
            }
        }

        private void dgvDividas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dividaService == null) { return; }

            if (cmbClientes.SelectedItem is not Cliente cliente)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            try
            {
                var dividas =
                    dividaService.ConsultarPorCliente(cliente.Id);

                dgvDividas.Rows.Clear();

                foreach (var divida in dividas)
                {
                    string situacao =
                        divida.Paga ? "Paga" : "Em aberto";

                    string dataPagamento =
                        divida.DataPagamento.HasValue
                        ? divida.DataPagamento.Value.ToString("dd/MM/yyyy HH:mm")
                        : "";

                    dgvDividas.Rows.Add(
                        divida.Id,
                        divida.Valor.ToString("C2"),
                        situacao,
                        divida.DataCriacao.ToString("dd/MM/yyyy HH:mm"),
                        dataPagamento
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao consultar dívidas:\n" + ex.Message
                );
            }
        }

        private void btnMarcarPaga_Click(object sender, EventArgs e)
        {
            if (dividaService == null) { return; }

            if (cmbClientes.SelectedItem is not Cliente cliente)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            if (dgvDividas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma dívida na tabela.");
                return;
            }

            var linha = dgvDividas.SelectedRows[0];

            int dividaId = Convert.ToInt32(
                linha.Cells["Id"].Value
            );

            if (linha.Cells["Situacao"].Value?.ToString() == "Paga")
            {
                MessageBox.Show("Esta dívida já foi paga.");
                return;
            }

            var resposta = MessageBox.Show(
                "Deseja realmente marcar esta dívida como paga?",
                "Confirmar pagamento",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool resultado = dividaService.MarcarComoPaga(dividaId, cliente.Id);

                if (resultado)
                {
                    MessageBox.Show("Dívida paga com sucesso!");
                    btnConsultar_Click(sender, e);
                }
                else { MessageBox.Show("Não foi possível marcar esta dívida como paga."); }
            }
            catch (Exception ex) {MessageBox.Show("Erro ao registrar pagamento:\n" + ex.Message); }

        }
    }
}
