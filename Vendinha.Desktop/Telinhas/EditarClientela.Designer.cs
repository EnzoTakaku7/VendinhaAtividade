namespace Vendinha.Desktop.Telinhas
{
    partial class EditarClientela
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
            lblNascimento = new Label();
            dtpNascimento = new DateTimePicker();
            lblNome = new Label();
            txtNome = new TextBox();
            lblCPF = new Label();
            txtCPF = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // lblNascimento
            // 
            lblNascimento.AutoSize = true;
            lblNascimento.Location = new Point(35, 173);
            lblNascimento.Name = "lblNascimento";
            lblNascimento.Size = new Size(114, 15);
            lblNascimento.TabIndex = 4;
            lblNascimento.Text = "Data de Nascimento";
            // 
            // dtpNascimento
            // 
            dtpNascimento.Location = new Point(35, 205);
            dtpNascimento.Name = "dtpNascimento";
            dtpNascimento.Size = new Size(244, 23);
            dtpNascimento.TabIndex = 5;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(35, 34);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(96, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome Completo";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(35, 65);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 1;
            // 
            // lblCPF
            // 
            lblCPF.AutoSize = true;
            lblCPF.Location = new Point(35, 104);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(28, 15);
            lblCPF.TabIndex = 2;
            lblCPF.Text = "CPF";
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(35, 133);
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(100, 23);
            txtCPF.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(35, 278);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(35, 246);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(307, 338);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(181, 59);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Salvar Alterações";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // EditarClientela
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalvar);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(dtpNascimento);
            Controls.Add(lblNascimento);
            Controls.Add(txtCPF);
            Controls.Add(lblCPF);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Name = "EditarClientela";
            Text = "EditarClientela";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNascimento;
        private DateTimePicker dtpNascimento;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblCPF;
        private TextBox txtCPF;
        private TextBox txtEmail;
        private Label lblEmail;
        private Button btnSalvar;
    }
}