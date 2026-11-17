namespace Vendinha.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAbrirCadastro = new Button();
            btnAbrirListagem = new Button();
            btnCadastrarDivida = new Button();
            btnListarDividas = new Button();
            SuspendLayout();
            // 
            // btnAbrirCadastro
            // 
            btnAbrirCadastro.Location = new Point(592, 29);
            btnAbrirCadastro.Name = "btnAbrirCadastro";
            btnAbrirCadastro.Size = new Size(151, 47);
            btnAbrirCadastro.TabIndex = 0;
            btnAbrirCadastro.Text = "Cadastrar Cliente";
            btnAbrirCadastro.UseVisualStyleBackColor = true;
            btnAbrirCadastro.Click += btnCadastro_Click;
            // 
            // btnAbrirListagem
            // 
            btnAbrirListagem.Location = new Point(592, 94);
            btnAbrirListagem.Name = "btnAbrirListagem";
            btnAbrirListagem.Size = new Size(151, 45);
            btnAbrirListagem.TabIndex = 1;
            btnAbrirListagem.Text = "Ver Listagem";
            btnAbrirListagem.UseVisualStyleBackColor = true;
            btnAbrirListagem.Click += btnAbrirListagem_Click;
            // 
            // btnCadastrarDivida
            // 
            btnCadastrarDivida.Location = new Point(592, 162);
            btnCadastrarDivida.Name = "btnCadastrarDivida";
            btnCadastrarDivida.Size = new Size(155, 45);
            btnCadastrarDivida.TabIndex = 2;
            btnCadastrarDivida.Text = "Cadastrar Dívida";
            btnCadastrarDivida.UseVisualStyleBackColor = true;
            btnCadastrarDivida.Click += btnCadastrarDivida_Click;
            // 
            // btnListarDividas
            // 
            btnListarDividas.Location = new Point(592, 226);
            btnListarDividas.Name = "btnListarDividas";
            btnListarDividas.Size = new Size(151, 44);
            btnListarDividas.TabIndex = 3;
            btnListarDividas.Text = "Listar Dívidas";
            btnListarDividas.UseVisualStyleBackColor = true;
            btnListarDividas.Click += btnListarDividas_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnListarDividas);
            Controls.Add(btnCadastrarDivida);
            Controls.Add(btnAbrirListagem);
            Controls.Add(btnAbrirCadastro);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnAbrirCadastro;
        private Button btnAbrirListagem;
        private Button btnCadastrarDivida;
        private Button btnListarDividas;
    }
}
