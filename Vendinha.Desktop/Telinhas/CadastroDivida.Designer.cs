namespace Vendinha.Desktop.Telinhas
{
    partial class CadastroDivida
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
            lblValor = new Label();
            txtValor = new TextBox();
            btnCadastrar = new Button();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(104, 44);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(106, 62);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(121, 23);
            cmbClientes.TabIndex = 1;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(104, 123);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(84, 15);
            lblValor.TabIndex = 2;
            lblValor.Text = "Valor da dívida";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(106, 141);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(100, 23);
            txtValor.TabIndex = 3;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(298, 239);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(194, 43);
            btnCadastrar.TabIndex = 4;
            btnCadastrar.Text = "Cadastrar dívida";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // CadastroDivida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCadastrar);
            Controls.Add(txtValor);
            Controls.Add(lblValor);
            Controls.Add(cmbClientes);
            Controls.Add(lblCliente);
            Name = "CadastroDivida";
            Text = "CadastroDivida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private ComboBox cmbClientes;
        private Label lblValor;
        private TextBox txtValor;
        private Button btnCadastrar;
    }
}