namespace TestePraticoDevCSharp
{
    partial class FrmClienteCadastro
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
            label2 = new Label();
            btnLimpar = new Button();
            btnExcluir = new Button();
            btnSalvar = new Button();
            txtNome = new TextBox();
            label1 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            txtTelefone = new MaskedTextBox();
            label4 = new Label();
            txtId = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(173, 1);
            label2.Name = "label2";
            label2.Size = new Size(296, 37);
            label2.TabIndex = 5;
            label2.Text = "CADASTRO DE CLIENTE";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(277, 202);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(88, 25);
            btnLimpar.TabIndex = 2;
            btnLimpar.TabStop = false;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(371, 202);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(88, 25);
            btnExcluir.TabIndex = 3;
            btnExcluir.TabStop = false;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(183, 202);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(88, 25);
            btnSalvar.TabIndex = 4;
            btnSalvar.TabStop = false;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(129, 72);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(497, 25);
            txtNome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(126, 50);
            label1.Name = "label1";
            label1.Size = new Size(53, 19);
            label1.TabIndex = 7;
            label1.Text = "NOME:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(0, 0, 64);
            label3.Location = new Point(126, 120);
            label3.Name = "label3";
            label3.Size = new Size(58, 19);
            label3.TabIndex = 7;
            label3.Text = "E-MAIL:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(129, 142);
            txtEmail.MaxLength = 200;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(497, 25);
            txtEmail.TabIndex = 2;
            // 
            // txtTelefone
            // 
            txtTelefone.Font = new Font("Segoe UI", 10F);
            txtTelefone.Location = new Point(20, 142);
            txtTelefone.Mask = "(99) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(100, 25);
            txtTelefone.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(0, 0, 64);
            label4.Location = new Point(17, 120);
            label4.Name = "label4";
            label4.Size = new Size(75, 19);
            label4.TabIndex = 7;
            label4.Text = "TELEFONE:";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(20, 72);
            txtId.MaxLength = 100;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 25);
            txtId.TabIndex = 6;
            txtId.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(0, 0, 64);
            label5.Location = new Point(17, 50);
            label5.Name = "label5";
            label5.Size = new Size(26, 19);
            label5.TabIndex = 7;
            label5.Text = "ID:";
            // 
            // FrmClienteCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 270);
            Controls.Add(txtTelefone);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(txtNome);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnLimpar);
            Controls.Add(btnExcluir);
            Controls.Add(btnSalvar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmClienteCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button btnLimpar;
        private Button btnExcluir;
        private Button btnSalvar;
        private TextBox txtNome;
        private Label label1;
        private Label label3;
        private TextBox txtEmail;
        private MaskedTextBox txtTelefone;
        private Label label4;
        private TextBox txtId;
        private Label label5;
    }
}