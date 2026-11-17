namespace Vendinha.Desktop.Telinhas
{
    partial class ListarDividas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCliente = new Label();
            cmbClientes = new ComboBox();
            btnConsultar = new Button();
            dgvDividas = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            Situacao = new DataGridViewTextBoxColumn();
            DataCriacao = new DataGridViewTextBoxColumn();
            DataPagamento = new DataGridViewTextBoxColumn();
            btnMarcarPaga = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDividas).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(60, 155);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(105, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Selecione o cliente";
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(51, 183);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(121, 23);
            cmbClientes.TabIndex = 1;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(76, 249);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(75, 23);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar Dívidas";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dgvDividas
            // 
            dgvDividas.AllowUserToAddRows = false;
            dgvDividas.AllowUserToDeleteRows = false;
            dgvDividas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDividas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDividas.Columns.AddRange(new DataGridViewColumn[] { Id, Valor, Situacao, DataCriacao, DataPagamento });
            dgvDividas.Location = new Point(235, 22);
            dgvDividas.MultiSelect = false;
            dgvDividas.Name = "dgvDividas";
            dgvDividas.ReadOnly = true;
            dgvDividas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDividas.Size = new Size(509, 326);
            dgvDividas.TabIndex = 3;
            dgvDividas.CellContentClick += dgvDividas_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Valor
            // 
            Valor.HeaderText = "Valor";
            Valor.Name = "Valor";
            Valor.ReadOnly = true;
            // 
            // Situacao
            // 
            Situacao.HeaderText = "Situação";
            Situacao.Name = "Situacao";
            Situacao.ReadOnly = true;
            // 
            // DataCriacao
            // 
            DataCriacao.HeaderText = "Data de criação";
            DataCriacao.Name = "DataCriacao";
            DataCriacao.ReadOnly = true;
            // 
            // DataPagamento
            // 
            DataPagamento.HeaderText = "Data de pagamento";
            DataPagamento.Name = "DataPagamento";
            DataPagamento.ReadOnly = true;
            // 
            // btnMarcarPaga
            // 
            btnMarcarPaga.Location = new Point(422, 367);
            btnMarcarPaga.Name = "btnMarcarPaga";
            btnMarcarPaga.Size = new Size(148, 38);
            btnMarcarPaga.TabIndex = 4;
            btnMarcarPaga.Text = "Marcar como Paga";
            btnMarcarPaga.UseVisualStyleBackColor = true;
            btnMarcarPaga.Click += btnMarcarPaga_Click;
            // 
            // ListarDividas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMarcarPaga);
            Controls.Add(dgvDividas);
            Controls.Add(btnConsultar);
            Controls.Add(cmbClientes);
            Controls.Add(lblCliente);
            Name = "ListarDividas";
            Text = "ListarDividas";
            ((System.ComponentModel.ISupportInitialize)dgvDividas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private ComboBox cmbClientes;
        private Button btnConsultar;
        private DataGridView dgvDividas;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Valor;
        private DataGridViewTextBoxColumn Situacao;
        private DataGridViewTextBoxColumn DataCriacao;
        private DataGridViewTextBoxColumn DataPagamento;
        private Button btnMarcarPaga;
    }
}