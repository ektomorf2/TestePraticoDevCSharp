namespace TestePraticoDevCSharp
{
    partial class FrmClienteConsulta
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
            btnConsultar = new Button();
            label1 = new Label();
            txtConsulta = new TextBox();
            label2 = new Label();
            btnLimpar = new Button();
            grd = new DataGridView();
            btnNovo = new Button();
            Id = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Telefone = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)grd).BeginInit();
            SuspendLayout();
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(526, 70);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(88, 25);
            btnConsultar.TabIndex = 0;
            btnConsultar.TabStop = false;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(0, 0, 64);
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(333, 19);
            label1.TabIndex = 1;
            label1.Text = "INFORME TODO, OU PARTE DO NOME DO CLIENTE:";
            // 
            // txtConsulta
            // 
            txtConsulta.Font = new Font("Segoe UI", 10F);
            txtConsulta.Location = new Point(12, 70);
            txtConsulta.Name = "txtConsulta";
            txtConsulta.Size = new Size(497, 25);
            txtConsulta.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Underline);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(261, 1);
            label2.Name = "label2";
            label2.Size = new Size(292, 37);
            label2.TabIndex = 1;
            label2.Text = "CONSULTA DE CLIENTE";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(620, 70);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(88, 25);
            btnLimpar.TabIndex = 0;
            btnLimpar.TabStop = false;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // grd
            // 
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
            grd.AllowUserToOrderColumns = true;
            grd.BackgroundColor = SystemColors.ControlLightLight;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grd.Columns.AddRange(new DataGridViewColumn[] { Id, Nome, Email, Telefone });
            grd.Location = new Point(12, 111);
            grd.Name = "grd";
            grd.ReadOnly = true;
            grd.Size = new Size(790, 326);
            grd.TabIndex = 3;
            grd.TabStop = false;
            grd.DoubleClick += grd_DoubleClick;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(714, 70);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(88, 25);
            btnNovo.TabIndex = 0;
            btnNovo.TabStop = false;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
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
            // Email
            // 
            Email.HeaderText = "E-Mail";
            Email.Name = "Email";
            Email.ReadOnly = true;
            Email.Width = 345;
            // 
            // Telefone
            // 
            Telefone.HeaderText = "Telefone";
            Telefone.Name = "Telefone";
            Telefone.ReadOnly = true;
            // 
            // FrmClienteConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 449);
            Controls.Add(grd);
            Controls.Add(txtConsulta);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLimpar);
            Controls.Add(btnNovo);
            Controls.Add(btnConsultar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmClienteConsulta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Consulta de Cliente";
            ((System.ComponentModel.ISupportInitialize)grd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConsultar;
        private Label label1;
        private TextBox txtConsulta;
        private Label label2;
        private Button btnLimpar;
        private DataGridView grd;
        private Button btnNovo;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Telefone;
    }
}