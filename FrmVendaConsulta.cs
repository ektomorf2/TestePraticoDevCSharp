using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp
{
    public partial class FrmVendaConsulta : Form
    {
        private readonly IVendaService _vendaService;
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;

        List<cliente> clientes = [];

        public FrmVendaConsulta(IVendaService vendaService, IClienteService clienteService, IProdutoService produtoService)
        {
            InitializeComponent();

            _clienteService = clienteService;
            _vendaService = vendaService;
            _produtoService = produtoService;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDataIni.Clear();
            txtDataFim.Clear();
            cboCliente.SelectedIndex = -1;
            cboCliente.Focus();
        }

        async void FrmVendaConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                txtDataIni.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToShortDateString();
                txtDataFim.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToShortDateString();

                clientes = await _clienteService.Listar();

                if (!Util.ListOk(clientes)) return;

                clientes = [.. clientes.OrderBy(c => c.nome)];

                cboCliente.DisplayMember = "nome";
                cboCliente.ValueMember = "id";

                cboCliente.Items.AddRange([.. clientes]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task Consultar(bool informarNadaEncontrado = true)
        {
            try
            {
                grd.Rows.Clear();

                List<venda> vendas = await _vendaService.ListarVenda(
                    new venda
                    {
                        dataIni = Util.Nada(txtDataIni.Text) ? DateTime.MinValue : Convert.ToDateTime(txtDataIni.Text),
                        dataFim = Util.Nada(txtDataFim.Text) ? DateTime.MinValue : Convert.ToDateTime(txtDataFim.Text),
                        idcliente = cboCliente.SelectedItem != null ? ((cliente)cboCliente.SelectedItem).id : 0
                    }
                );

                if (!Util.ListOk(vendas) && informarNadaEncontrado)
                {
                    MessageBox.Show("Nenhuma venda encontrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (venda v in vendas)
                {
                    grd.Rows.Add(v.id, v.cliente, Util.Decimais(v.total), v.datahora);
                    grd.Rows[grd.RowCount - 1].Tag = v;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void btnConsultar_Click(object sender, EventArgs e)
        {
            await Consultar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new FrmVendaCadastro(new venda(), clientes, _vendaService, _produtoService).ShowDialog();
        }

        async void grd_DoubleClick(object sender, EventArgs e)
        {
            if (grd.RowCount == 0) return;

            venda venda = (venda)grd.CurrentRow.Tag;

            new FrmVendaCadastro(venda, clientes, _vendaService, _produtoService).ShowDialog();

            await Consultar(false);
        }
    }
}
