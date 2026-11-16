namespace Vendinha.Desktop.Telinhas
{
    partial class ListarClientela
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
            dgvClientes = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNome = new DataGridViewTextBoxColumn();
            ColCPF = new DataGridViewTextBoxColumn();
            ColNascimento = new DataGridViewTextBoxColumn();
            ColIdade = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            lblPesquisa = new Label();
            txtPesquisa = new TextBox();
            btnPesquisar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colId, colNome, ColCPF, ColNascimento, ColIdade, colEmail });
            dgvClientes.Location = new Point(76, 125);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.Size = new Size(601, 300);
            dgvClientes.TabIndex = 0;
            dgvClientes.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colNome
            // 
            colNome.HeaderText = "Nome completo";
            colNome.Name = "colNome";
            colNome.ReadOnly = true;
            // 
            // ColCPF
            // 
            ColCPF.HeaderText = "CPF";
            ColCPF.Name = "ColCPF";
            ColCPF.ReadOnly = true;
            // 
            // ColNascimento
            // 
            ColNascimento.HeaderText = "Data de nascimento";
            ColNascimento.Name = "ColNascimento";
            ColNascimento.ReadOnly = true;
            // 
            // ColIdade
            // 
            ColIdade.HeaderText = "Idade";
            ColIdade.Name = "ColIdade";
            ColIdade.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // lblPesquisa
            // 
            lblPesquisa.AutoSize = true;
            lblPesquisa.Location = new Point(88, 20);
            lblPesquisa.Name = "lblPesquisa";
            lblPesquisa.Size = new Size(108, 15);
            lblPesquisa.TabIndex = 1;
            lblPesquisa.Text = "Pesquisar Cliente - ";
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(192, 17);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(100, 23);
            txtPesquisa.TabIndex = 2;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(298, 11);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(91, 32);
            btnPesquisar.TabIndex = 3;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // ListarClientela
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPesquisar);
            Controls.Add(txtPesquisa);
            Controls.Add(lblPesquisa);
            Controls.Add(dgvClientes);
            Name = "ListarClientela";
            Text = "ListarClientela";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNome;
        private DataGridViewTextBoxColumn ColCPF;
        private DataGridViewTextBoxColumn ColNascimento;
        private DataGridViewTextBoxColumn ColIdade;
        private DataGridViewTextBoxColumn colEmail;
        private Label lblPesquisa;
        private TextBox txtPesquisa;
        private Button btnPesquisar;
    }
}