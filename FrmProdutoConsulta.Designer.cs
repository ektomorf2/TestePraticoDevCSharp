namespace TestePraticoDevCSharp
{
    partial class FrmProdutoConsulta
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
            grd = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Descricao = new DataGridViewTextBoxColumn();
            Preco = new DataGridViewTextBoxColumn();
            Estoque = new DataGridViewTextBoxColumn();
            txtConsulta = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnLimpar = new Button();
            btnConsultar = new Button();
            btnNovo = new Button();
            ((System.ComponentModel.ISupportInitialize)grd).BeginInit();
            SuspendLayout();
            // 
            // grd
            // 
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
            grd.BackgroundColor = SystemColors.ControlLightLight;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grd.Columns.AddRange(new DataGridViewColumn[] { Id, Nome, Descricao, Preco, Estoque });
            grd.Location = new Point(12, 111);
            grd.Name = "grd";
            grd.ReadOnly = true;
            grd.Size = new Size(790, 326);
            grd.TabIndex = 9;
            grd.TabStop = false;
            grd.DoubleClick += grd_DoubleClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            Nome.Width = 200;
            // 
            // Descricao
            // 
            Descricao.HeaderText = "Descrição";
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            Descricao.Width = 245;
            // 
            // Preco
            // 
            Preco.HeaderText = "Preço";
            Preco.Name = "Preco";
            Preco.ReadOnly = true;
            // 
            // Estoque
            // 
            Estoque.HeaderText = "Estoque";
            Estoque.Name = "Estoque";
            Estoque.ReadOnly = true;
            // 
            // txtConsulta
            // 
            txtConsulta.Font = new Font("Segoe UI", 10F);
            txtConsulta.Location = new Point(12, 80);
            txtConsulta.Name = "txtConsulta";
            txtConsulta.Size = new Size(508, 25);
            txtConsulta.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(243, 1);
            label2.Name = "label2";
            label2.Size = new Size(315, 37);
            label2.TabIndex = 7;
            label2.Text = "CONSULTA DE PRODUTO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(12, 58);
            label1.Name = "label1";
            label1.Size = new Size(457, 19);
            label1.TabIndex = 8;
            label1.Text = "INFORME TODO, OU PARTE DO NOME  OU DESCRIÇÃO DO PRODUTO :";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(620, 80);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(88, 25);
            btnLimpar.TabIndex = 5;
            btnLimpar.TabStop = false;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(526, 80);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(88, 25);
            btnConsultar.TabIndex = 6;
            btnConsultar.TabStop = false;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(714, 80);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(88, 25);
            btnNovo.TabIndex = 10;
            btnNovo.TabStop = false;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // FrmProdutoConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 449);
            Controls.Add(btnNovo);
            Controls.Add(grd);
            Controls.Add(txtConsulta);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLimpar);
            Controls.Add(btnConsultar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmProdutoConsulta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Consulta de Produto";
            ((System.ComponentModel.ISupportInitialize)grd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grd;
        private TextBox txtConsulta;
        private Label label2;
        private Label label1;
        private Button btnLimpar;
        private Button btnConsultar;
        private Button btnNovo;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn Preco;
        private DataGridViewTextBoxColumn Estoque;
    }
}