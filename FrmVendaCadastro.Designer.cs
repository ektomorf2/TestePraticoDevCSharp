namespace TestePraticoDevCSharp
{
    partial class FrmVendaCadastro
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
            cboCliente = new ComboBox();
            grd = new DataGridView();
            produto = new DataGridViewTextBoxColumn();
            precounitario = new DataGridViewTextBoxColumn();
            qtd = new DataGridViewTextBoxColumn();
            total = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label3 = new Label();
            cboProduto = new ComboBox();
            btnSalvar = new Button();
            txtId = new TextBox();
            label5 = new Label();
            txtDataHora = new MaskedTextBox();
            label4 = new Label();
            label6 = new Label();
            txtTotal = new TextBox();
            label7 = new Label();
            txtPrecoUnitario = new TextBox();
            txtQuantidade = new TextBox();
            label8 = new Label();
            label9 = new Label();
            txtTotalItem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)grd).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(356, 2);
            label2.Name = "label2";
            label2.Size = new Size(103, 37);
            label2.TabIndex = 15;
            label2.Text = "VENDA";
            // 
            // cboCliente
            // 
            cboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCliente.Font = new Font("Segoe UI", 10F);
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(372, 67);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(430, 25);
            cboCliente.TabIndex = 0;
            // 
            // grd
            // 
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
            grd.AllowUserToOrderColumns = true;
            grd.BackgroundColor = SystemColors.ControlLightLight;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grd.Columns.AddRange(new DataGridViewColumn[] { produto, precounitario, qtd, total });
            grd.Location = new Point(3, 175);
            grd.Name = "grd";
            grd.ReadOnly = true;
            grd.Size = new Size(803, 326);
            grd.TabIndex = 18;
            grd.TabStop = false;
            // 
            // produto
            // 
            produto.HeaderText = "Produto";
            produto.Name = "produto";
            produto.ReadOnly = true;
            produto.Width = 400;
            // 
            // precounitario
            // 
            precounitario.HeaderText = "Preço Unitário R$";
            precounitario.Name = "precounitario";
            precounitario.ReadOnly = true;
            precounitario.Width = 120;
            // 
            // qtd
            // 
            qtd.HeaderText = "Qtde.";
            qtd.Name = "qtd";
            qtd.ReadOnly = true;
            qtd.Width = 90;
            // 
            // total
            // 
            total.HeaderText = "Total R$";
            total.Name = "total";
            total.ReadOnly = true;
            total.Width = 150;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(369, 45);
            label1.Name = "label1";
            label1.Size = new Size(163, 19);
            label1.TabIndex = 17;
            label1.Text = "SELECIONE UM CLIENTE:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(0, 0, 64);
            label3.Location = new Point(0, 114);
            label3.Name = "label3";
            label3.Size = new Size(176, 19);
            label3.TabIndex = 17;
            label3.Text = "SELECIONE UM PRODUTO:";
            // 
            // cboProduto
            // 
            cboProduto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProduto.FormattingEnabled = true;
            cboProduto.Location = new Point(3, 136);
            cboProduto.Name = "cboProduto";
            cboProduto.Size = new Size(350, 23);
            cboProduto.TabIndex = 1;
            cboProduto.SelectedIndexChanged += cboProduto_SelectedIndexChanged;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(718, 134);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(88, 25);
            btnSalvar.TabIndex = 20;
            btnSalvar.TabStop = false;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(6, 67);
            txtId.MaxLength = 100;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(76, 25);
            txtId.TabIndex = 21;
            txtId.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(0, 0, 64);
            label5.Location = new Point(3, 45);
            label5.Name = "label5";
            label5.Size = new Size(26, 19);
            label5.TabIndex = 22;
            label5.Text = "ID:";
            // 
            // txtDataHora
            // 
            txtDataHora.Font = new Font("Segoe UI", 10F);
            txtDataHora.Location = new Point(212, 67);
            txtDataHora.Mask = "00/00/0000 90:00";
            txtDataHora.Name = "txtDataHora";
            txtDataHora.ReadOnly = true;
            txtDataHora.Size = new Size(154, 25);
            txtDataHora.TabIndex = 24;
            txtDataHora.ValidatingType = typeof(DateTime);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(0, 0, 64);
            label4.Location = new Point(212, 45);
            label4.Name = "label4";
            label4.Size = new Size(96, 19);
            label4.TabIndex = 23;
            label4.Text = "DATA / HORA:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.FromArgb(0, 0, 64);
            label6.Location = new Point(88, 45);
            label6.Name = "label6";
            label6.Size = new Size(70, 19);
            label6.TabIndex = 22;
            label6.Text = "TOTAL R$:";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 10F);
            txtTotal.Location = new Point(88, 67);
            txtTotal.MaxLength = 100;
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(118, 25);
            txtTotal.TabIndex = 21;
            txtTotal.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = Color.FromArgb(0, 0, 64);
            label7.Location = new Point(488, 114);
            label7.Name = "label7";
            label7.Size = new Size(75, 19);
            label7.TabIndex = 22;
            label7.Text = "PREÇO R$:";
            // 
            // txtPrecoUnitario
            // 
            txtPrecoUnitario.Font = new Font("Segoe UI", 10F);
            txtPrecoUnitario.Location = new Point(488, 134);
            txtPrecoUnitario.MaxLength = 100;
            txtPrecoUnitario.Name = "txtPrecoUnitario";
            txtPrecoUnitario.ReadOnly = true;
            txtPrecoUnitario.Size = new Size(100, 25);
            txtPrecoUnitario.TabIndex = 21;
            txtPrecoUnitario.TabStop = false;
            // 
            // txtQuantidade
            // 
            txtQuantidade.Font = new Font("Segoe UI", 10F);
            txtQuantidade.Location = new Point(369, 134);
            txtQuantidade.MaxLength = 200;
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(107, 25);
            txtQuantidade.TabIndex = 25;
            txtQuantidade.Leave += txtQuantidade_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.ForeColor = Color.FromArgb(0, 0, 64);
            label8.Location = new Point(369, 112);
            label8.Name = "label8";
            label8.Size = new Size(46, 19);
            label8.TabIndex = 26;
            label8.Text = "QTDE:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = Color.FromArgb(0, 0, 64);
            label9.Location = new Point(603, 114);
            label9.Name = "label9";
            label9.Size = new Size(70, 19);
            label9.TabIndex = 22;
            label9.Text = "TOTAL R$:";
            // 
            // txtTotalItem
            // 
            txtTotalItem.Font = new Font("Segoe UI", 10F);
            txtTotalItem.Location = new Point(603, 134);
            txtTotalItem.MaxLength = 100;
            txtTotalItem.Name = "txtTotalItem";
            txtTotalItem.ReadOnly = true;
            txtTotalItem.Size = new Size(100, 25);
            txtTotalItem.TabIndex = 21;
            txtTotalItem.TabStop = false;
            // 
            // FrmVendaCadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 563);
            Controls.Add(txtQuantidade);
            Controls.Add(label8);
            Controls.Add(txtDataHora);
            Controls.Add(label4);
            Controls.Add(txtTotalItem);
            Controls.Add(label9);
            Controls.Add(txtPrecoUnitario);
            Controls.Add(label7);
            Controls.Add(txtTotal);
            Controls.Add(label6);
            Controls.Add(txtId);
            Controls.Add(label5);
            Controls.Add(btnSalvar);
            Controls.Add(cboProduto);
            Controls.Add(cboCliente);
            Controls.Add(label3);
            Controls.Add(grd);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmVendaCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Venda";
            Load += FrmVendaCadastro_Load;
            ((System.ComponentModel.ISupportInitialize)grd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private ComboBox cboCliente;
        private DataGridView grd;
        private Label label1;
        private Label label3;
        private ComboBox cboProduto;
        private Button btnSalvar;
        private TextBox txtId;
        private Label label5;
        private MaskedTextBox txtDataHora;
        private Label label4;
        private Label label6;
        private TextBox txtTotal;
        private Label label7;
        private TextBox txtPrecoUnitario;
        private TextBox txtQuantidade;
        private Label label8;
        private Label label9;
        private TextBox txtTotalItem;
        private DataGridViewTextBoxColumn produto;
        private DataGridViewTextBoxColumn precounitario;
        private DataGridViewTextBoxColumn qtd;
        private DataGridViewTextBoxColumn total;
    }
}