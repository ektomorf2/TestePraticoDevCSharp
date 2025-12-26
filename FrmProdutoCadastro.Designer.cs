namespace TestePraticoDevCSharp
{
    partial class FrmProdutoCadastro
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
            txtDescricao = new TextBox();
            label3 = new Label();
            txtId = new TextBox();
            txtNome = new TextBox();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            btnLimpar = new Button();
            btnExcluir = new Button();
            btnSalvar = new Button();
            label4 = new Label();
            txtPreco = new TextBox();
            label6 = new Label();
            txtEstoque = new TextBox();
            SuspendLayout();
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Segoe UI", 10F);
            txtDescricao.Location = new Point(20, 130);
            txtDescricao.MaxLength = 200;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(606, 25);
            txtDescricao.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(0, 0, 64);
            label3.Location = new Point(17, 108);
            label3.Name = "label3";
            label3.Size = new Size(86, 19);
            label3.TabIndex = 17;
            label3.Text = "DESCRIÇÃO:";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(20, 70);
            txtId.MaxLength = 100;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 25);
            txtId.TabIndex = 15;
            txtId.TabStop = false;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(129, 70);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(497, 25);
            txtNome.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(0, 0, 64);
            label5.Location = new Point(17, 48);
            label5.Name = "label5";
            label5.Size = new Size(26, 19);
            label5.TabIndex = 18;
            label5.Text = "ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(126, 48);
            label1.Name = "label1";
            label1.Size = new Size(53, 19);
            label1.TabIndex = 19;
            label1.Text = "NOME:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(162, 1);
            label2.Name = "label2";
            label2.Size = new Size(319, 37);
            label2.TabIndex = 14;
            label2.Text = "CADASTRO DE PRODUTO";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(277, 233);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(88, 25);
            btnLimpar.TabIndex = 11;
            btnLimpar.TabStop = false;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(371, 233);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(88, 25);
            btnExcluir.TabIndex = 12;
            btnExcluir.TabStop = false;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(183, 233);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(88, 25);
            btnSalvar.TabIndex = 13;
            btnSalvar.TabStop = false;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(0, 0, 64);
            label4.Location = new Point(17, 169);
            label4.Name = "label4";
            label4.Size = new Size(55, 19);
            label4.TabIndex = 17;
            label4.Text = "PREÇO:";
            // 
            // txtPreco
            // 
            txtPreco.Font = new Font("Segoe UI", 10F);
            txtPreco.Location = new Point(20, 191);
            txtPreco.MaxLength = 200;
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(107, 25);
            txtPreco.TabIndex = 2;
            txtPreco.KeyPress += txtPreco_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.FromArgb(0, 0, 64);
            label6.Location = new Point(130, 169);
            label6.Name = "label6";
            label6.Size = new Size(71, 19);
            label6.TabIndex = 17;
            label6.Text = "ESTOQUE:";
            // 
            // txtEstoque
            // 
            txtEstoque.Font = new Font("Segoe UI", 10F);
            txtEstoque.Location = new Point(133, 191);
            txtEstoque.MaxLength = 200;
            txtEstoque.Name = "txtEstoque";
            txtEstoque.Size = new Size(107, 25);
            txtEstoque.TabIndex = 3;
            txtEstoque.KeyPress += txtEstoque_KeyPress;
            // 
            // FrmProdutoCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 270);
            Controls.Add(txtEstoque);
            Controls.Add(label6);
            Controls.Add(txtPreco);
            Controls.Add(label4);
            Controls.Add(txtDescricao);
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
            Name = "FrmProdutoCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Produto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox txtTelefone;
        private TextBox txtDescricao;
        private Label label3;
        private TextBox txtId;
        private TextBox txtNome;
        private Label label5;
        private Label label1;
        private Label label2;
        private Button btnLimpar;
        private Button btnExcluir;
        private Button btnSalvar;
        private Label label4;
        private TextBox txtPreco;
        private Label label6;
        private TextBox txtEstoque;
    }
}