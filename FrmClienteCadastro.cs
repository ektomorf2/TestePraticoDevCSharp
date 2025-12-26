using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp
{
    public partial class FrmClienteCadastro : Form
    {
        readonly IClienteService _clienteService;
        cliente cliente;

        public FrmClienteCadastro(IClienteService clienteService, cliente c)
        {
            InitializeComponent();

            _clienteService = clienteService;

            cliente = c;

            if (c != null)
            {
                txtId.Text = cliente.id > 0 ? Convert.ToString(cliente.id) : "";
                txtNome.Text = cliente.nome;
                txtEmail.Text = cliente.email;
                txtTelefone.Text = cliente.telefone;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente.id = Util.Nada(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
                cliente.nome = txtNome.Text;
                cliente.email = txtEmail.Text;
                cliente.telefone = Util.FoneSemMascara(txtTelefone.Text);

                await _clienteService.Salvar(cliente);

                txtId.Text = Convert.ToString(cliente.id);

                MessageBox.Show("Dados Salvos com Sucesso!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (cliente.id == 0) return;

            if(MessageBox.Show("Confirma a exclusão deste cliente?", "Cadastro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                await _clienteService.Excluir(cliente.id);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
