using Microsoft.Reporting.WinForms;
using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp
{
    public partial class FrmVendaRelatorio : Form
    {
        private ReportViewer reportViewer;

        public FrmVendaRelatorio()
        {
            InitializeComponent();

            try
            {
                reportViewer = new()
                {
                    Dock = DockStyle.Fill
                };

                Controls.Add(reportViewer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Relatório de Vendas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmVendaRelatorio_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.ReportPath = "Relatorios/RelatorioVendas.rdlc";

                var dados = new List<venda>
                {
                    new ()
                    {
                        id = 1,
                        cliente = "Carlos", total = 100.50m
                    }
                };

                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetVendas", dados));
                reportViewer.RefreshReport();
            }

            catch { }


        }
    }
}
