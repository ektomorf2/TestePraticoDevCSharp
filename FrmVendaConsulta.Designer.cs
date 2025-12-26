namespace TestePraticoDevCSharp
{
    partial class FrmVendaConsulta
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
            id = new DataGridViewTextBoxColumn();
            cliente = new DataGridViewTextBoxColumn();
            total = new DataGridViewTextBoxColumn();
            datahora = new DataGridViewTextBoxColumn();
            label2 = new Label();
            label1 = new Label();
            btnLimpar = new Button();
            btnConsultar = new Button();
            cboCliente = new ComboBox();
            txtDataIni = new MaskedTextBox();
            label3 = new Label();
            label4 = new Label();
            txtDataFim = new MaskedTextBox();
            btnNovo = new Button();
            ((System.ComponentModel.ISupportInitialize)grd).BeginInit();
            SuspendLayout();
            // 
            // grd
            // 
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
            grd.AllowUserToOrderColumns = true;
            grd.BackgroundColor = SystemColors.ControlLightLight;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grd.Columns.AddRange(new DataGridViewColumn[] { id, cliente, total, datahora });
            grd.Location = new Point(6, 111);
            grd.Name = "grd";
            grd.ReadOnly = true;
            grd.Size = new Size(803, 326);
            grd.TabIndex = 15;
            grd.TabStop = false;
            grd.DoubleClick += grd_DoubleClick;
            // 
            // id
            // 
            id.HeaderText = "Id";
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // cliente
            // 
            cliente.HeaderText = "Cliente";
            cliente.Name = "cliente";
            cliente.ReadOnly = true;
            cliente.Width = 360;
            // 
            // total
            // 
            total.HeaderText = "Total R$";
            total.Name = "total";
            total.ReadOnly = true;
            total.Width = 150;
            // 
            // datahora
            // 
            datahora.HeaderText = "Data/Hora";
            datahora.Name = "datahora";
            datahora.ReadOnly = true;
            datahora.Width = 150;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(268, 4);
            label2.Name = "label2";
            label2.Size = new Size(279, 37);
            label2.TabIndex = 13;
            label2.Text = "CONSULTA DE VENDA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(6, 60);
            label1.Name = "label1";
            label1.Size = new Size(163, 19);
            label1.TabIndex = 14;
            label1.Text = "SELECIONE UM CLIENTE:";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(628, 80);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(88, 25);
            btnLimpar.TabIndex = 11;
            btnLimpar.TabStop = false;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(534, 80);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(88, 25);
            btnConsultar.TabIndex = 12;
            btnConsultar.TabStop = false;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // cboCliente
            // 
            cboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(6, 80);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(350, 23);
            cboCliente.TabIndex = 16;
            // 
            // txtDataIni
            // 
            txtDataIni.Location = new Point(365, 80);
            txtDataIni.Mask = "00/00/0000";
            txtDataIni.Name = "txtDataIni";
            txtDataIni.Size = new Size(76, 23);
            txtDataIni.TabIndex = 17;
            txtDataIni.ValidatingType = typeof(DateTime);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(0, 0, 64);
            label3.Location = new Point(365, 60);
            label3.Name = "label3";
            label3.Size = new Size(54, 19);
            label3.TabIndex = 14;
            label3.Text = "INÍCIO:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.FromArgb(0, 0, 64);
            label4.Location = new Point(447, 60);
            label4.Name = "label4";
            label4.Size = new Size(36, 19);
            label4.TabIndex = 14;
            label4.Text = "FIM:";
            // 
            // txtDataFim
            // 
            txtDataFim.Location = new Point(447, 80);
            txtDataFim.Mask = "00/00/0000";
            txtDataFim.Name = "txtDataFim";
            txtDataFim.Size = new Size(76, 23);
            txtDataFim.TabIndex = 17;
            txtDataFim.ValidatingType = typeof(DateTime);
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(722, 80);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(88, 25);
            btnNovo.TabIndex = 18;
            btnNovo.TabStop = false;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // FrmVendaConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 449);
            Controls.Add(btnNovo);
            Controls.Add(txtDataFim);
            Controls.Add(txtDataIni);
            Controls.Add(cboCliente);
            Controls.Add(grd);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnLimpar);
            Controls.Add(btnConsultar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmVendaConsulta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Consulta de Venda";
            Load += FrmVendaConsulta_Load;
            ((System.ComponentModel.ISupportInitialize)grd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grd;
        private Label label2;
        private Label label1;
        private Button btnLimpar;
        private Button btnConsultar;
        private ComboBox cboCliente;
        private MaskedTextBox txtDataIni;
        private Label label3;
        private Label label4;
        private MaskedTextBox txtDataFim;
        private Button btnNovo;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn cliente;
        private DataGridViewTextBoxColumn total;
        private DataGridViewTextBoxColumn datahora;
    }
}