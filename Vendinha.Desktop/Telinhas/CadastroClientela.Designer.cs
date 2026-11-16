namespace Vendinha.Desktop.Telinhas
{
    partial class CadastroClientela
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
            lblNome = new Label();
            txtNome = new TextBox();
            lblCPF = new Label();
            textBox1 = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblNascimento = new Label();
            DTPNascimento = new DateTimePicker();
            btnCadastrar = new Button();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(33, 33);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(99, 15);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome Completo:";
            lblNome.Click += label1_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(32, 51);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(201, 23);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += txtNome_TextChanged;
            // 
            // lblCPF
            // 
            lblCPF.AutoSize = true;
            lblCPF.Location = new Point(33, 86);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(31, 15);
            lblCPF.TabIndex = 2;
            lblCPF.Text = "CPF:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(32, 114);
            textBox1.MaxLength = 11;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 23);
            textBox1.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(33, 250);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(33, 223);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email: ";
            lblEmail.Click += label2_Click;
            // 
            // lblNascimento
            // 
            lblNascimento.AutoSize = true;
            lblNascimento.Location = new Point(32, 152);
            lblNascimento.Name = "lblNascimento";
            lblNascimento.Size = new Size(115, 15);
            lblNascimento.TabIndex = 4;
            lblNascimento.Text = "Data de nascimento:";
            // 
            // DTPNascimento
            // 
            DTPNascimento.Format = DateTimePickerFormat.Short;
            DTPNascimento.Location = new Point(33, 184);
            DTPNascimento.Name = "DTPNascimento";
            DTPNascimento.Size = new Size(200, 23);
            DTPNascimento.TabIndex = 8;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(607, 355);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(155, 58);
            btnCadastrar.TabIndex = 9;
            btnCadastrar.Text = "Cadastrar\r\n";
            btnCadastrar.UseVisualStyleBackColor = true;
            // 
            // CadastroClientela
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCadastrar);
            Controls.Add(DTPNascimento);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblNascimento);
            Controls.Add(textBox1);
            Controls.Add(lblCPF);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Name = "CadastroClientela";
            Text = "CadastroClientela";
            Load += CadastroClientela_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private TextBox txtNome;
        private Label lblCPF;
        private TextBox textBox1;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblNascimento;
        private DateTimePicker DTPNascimento;
        private Button btnCadastrar;
    }
}