using Microsoft.Extensions.DependencyInjection;
using TestePraticoDevCSharp.Interfaces.Service;

namespace TestePraticoDevCSharp
{
    public partial class FrmPrincipal : Form
    {
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;
        private readonly IVendaService _vendaService;
        private readonly IServiceProvider _provider;

        public FrmPrincipal(
            IClienteService clienteService,
            IProdutoService produtoService,
            IVendaService vendaService,
            IServiceProvider provider)
        {
            InitializeComponent();
            _clienteService = clienteService;
            _produtoService = produtoService;
            _vendaService = vendaService;
            _provider = provider;
        }

        private void mnuCliente_Click(object sender, EventArgs e)
        {
            FrmClienteConsulta frmClienteConsulta = _provider.GetRequiredService<FrmClienteConsulta>();
            frmClienteConsulta.Show();
        }

        private void mnuProduto_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProdutoConsulta frmProdutoConsulta = _provider.GetRequiredService<FrmProdutoConsulta>();
                frmProdutoConsulta.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuVendas_Click(object sender, EventArgs e)
        {
            FrmVendaConsulta frmVendaConsulta = _provider.GetRequiredService<FrmVendaConsulta>();
            frmVendaConsulta.Show();
        }

        private void mnuRelatorio_Click(object sender, EventArgs e)
        {
            new FrmVendaRelatorio().Show();
        }
    }
}
