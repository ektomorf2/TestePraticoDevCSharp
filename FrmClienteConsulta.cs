using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp
{
    public partial class FrmClienteConsulta : Form
    {
        private readonly IClienteService _clienteService;

        public FrmClienteConsulta(IClienteService clienteService)
        {
            _clienteService = clienteService;
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtConsulta.Clear();
            txtConsulta.Focus();
        }

        async Task Consultar(bool informarNadaEncontrado = true)
        {
            try
            {
                grd.Rows.Clear();

                List<cliente> clientes = await _clienteService.Listar(txtConsulta.Text);

                if (!Util.ListOk(clientes))
                {
                    MessageBox.Show("Nenhum cliente encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (cliente cliente in clientes)
                {
                    grd.Rows.Add(
                    [
                        cliente.id,
                        cliente.nome,
                        cliente.email,
                        cliente.telefone
                    ]);

                    grd.Rows[grd.RowCount - 1].Tag = cliente;
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
            new FrmClienteCadastro(_clienteService, new cliente()).ShowDialog();
        }

        private async void grd_DoubleClick(object sender, EventArgs e)
        {
            if (grd.RowCount == 0) return;

            cliente? cliente = (cliente)grd.CurrentRow.Tag;

            new FrmClienteCadastro(_clienteService, cliente).ShowDialog();

            await Consultar(false);
        }
    }
}
