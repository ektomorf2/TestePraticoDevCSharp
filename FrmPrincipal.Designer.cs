namespace TestePraticoDevCSharp
{
    partial class FrmPrincipal
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
            menu = new MenuStrip();
            mnuCadastro = new ToolStripMenuItem();
            mnuCliente = new ToolStripMenuItem();
            mnuProduto = new ToolStripMenuItem();
            mnuVenda = new ToolStripMenuItem();
            mnuVendas = new ToolStripMenuItem();
            mnuRelatorio = new ToolStripMenuItem();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { mnuCadastro, mnuVenda });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 24);
            menu.TabIndex = 1;
            menu.Text = "menuStrip1";
            // 
            // mnuCadastro
            // 
            mnuCadastro.DropDownItems.AddRange(new ToolStripItem[] { mnuCliente, mnuProduto });
            mnuCadastro.Name = "mnuCadastro";
            mnuCadastro.Size = new Size(66, 20);
            mnuCadastro.Text = "Cadastro";
            // 
            // mnuCliente
            // 
            mnuCliente.Name = "mnuCliente";
            mnuCliente.Size = new Size(117, 22);
            mnuCliente.Text = "Cliente";
            mnuCliente.Click += mnuCliente_Click;
            // 
            // mnuProduto
            // 
            mnuProduto.Name = "mnuProduto";
            mnuProduto.Size = new Size(117, 22);
            mnuProduto.Text = "Produto";
            mnuProduto.Click += mnuProduto_Click;
            // 
            // mnuVenda
            // 
            mnuVenda.DropDownItems.AddRange(new ToolStripItem[] { mnuVendas, mnuRelatorio });
            mnuVenda.Name = "mnuVenda";
            mnuVenda.Size = new Size(51, 20);
            mnuVenda.Text = "Venda";
            // 
            // mnuVendas
            // 
            mnuVendas.Name = "mnuVendas";
            mnuVendas.Size = new Size(180, 22);
            mnuVendas.Text = "Vendas";
            mnuVendas.Click += mnuVendas_Click;
            // 
            // mnuRelatorio
            // 
            mnuRelatorio.Name = "mnuRelatorio";
            mnuRelatorio.Size = new Size(180, 22);
            mnuRelatorio.Text = "Relatório";
            mnuRelatorio.Click += mnuRelatorio_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menu);
            IsMdiContainer = true;
            MainMenuStrip = menu;
            Name = "FrmPrincipal";
            Text = "TestePraticoDevCSharp";
            WindowState = FormWindowState.Maximized;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem mnuCadastro;
        private ToolStripMenuItem mnuCliente;
        private ToolStripMenuItem mnuProduto;
        private ToolStripMenuItem mnuVenda;
        private ToolStripMenuItem mnuVendas;
        private ToolStripMenuItem mnuRelatorio;
    }
}
