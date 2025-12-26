using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp
{
    public partial class FrmVendaCadastro : Form
    {
        private readonly IVendaService _vendaService;
        private readonly IProdutoService _produtoService;

        venda venda = new();

        public FrmVendaCadastro(venda v, List<cliente> clientes, IVendaService vendaService, IProdutoService produtoService)
        {
            InitializeComponent();

            venda = v;

            _vendaService = vendaService;

            _produtoService = produtoService;

            if (Util.ListOk(clientes))
            {
                clientes = [.. clientes.OrderBy(x => x.nome)];

                cboCliente.DisplayMember = "nome";
                cboCliente.ValueMember = "id";
                cboCliente.Items.AddRange([.. clientes]);
            }
        }

        void LimpaItem()
        {
            txtQuantidade.Clear();
            txtPrecoUnitario.Clear();
            txtTotalItem.Clear();
            txtQuantidade.Focus();
        }

        void CalculaTotalItem()
        {
            try
            {
                if(cboProduto.Items.Count == 0 || cboProduto.SelectedIndex < 0 || Util.Nada(txtQuantidade.Text)) return;

                produto p = (produto)cboProduto.SelectedItem;

                decimal total = _vendaService.CalculaTotalItem(p.preco, Convert.ToDecimal(txtQuantidade.Text));
                
                txtTotalItem.Text = Util.Decimais(total);
            }
            catch { }
        }

        void AtualizaVendaLocal()
        {
            txtId.Text = Convert.ToString(venda.id);
            txtTotal.Text = Util.Decimais(venda.total);
            txtDataHora.Text = venda.datahora.ToString();

            foreach(cliente c in cboCliente.Items)
            {
                if (c.id == venda.idcliente)
                {
                    cboCliente.SelectedItem = c;
                    break;
                }
            }

            grd.Rows.Clear();

            if (!Util.ListOk(venda.itens)) return;

            foreach (vendaitem vi in venda.itens.OrderBy(x => x.produto))
            {
                grd.Rows.Add(
                    vi.produto,
                    Util.Decimais(vi.precounitario),
                    Util.Decimais(vi.quantidade),
                    Util.Decimais(vi.total)
                );

                grd.Rows[grd.RowCount - 1].Tag = vi;
            }
        }

        async void FrmVendaCadastro_Load(object sender, EventArgs e)
        {
            try
            {
                List<produto> produtos = await _produtoService.Listar();

                if (Util.ListOk(produtos))
                {
                    produtos = [.. produtos.OrderBy(x => x.nome)];

                    cboProduto.ValueMember = "id";
                    cboProduto.DisplayMember = "nome";
                    cboProduto.Items.AddRange([.. produtos]);
                }

                if (venda.id > 0)
                {
                    venda.itens = await _vendaService.ListarItem(venda.id);

                    AtualizaVendaLocal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpaItem();

            if (cboProduto.Items.Count == 0 || cboProduto.SelectedIndex < 0) return;

            produto p = (produto)cboProduto.SelectedItem;

            txtPrecoUnitario.Text = Util.Decimais(p.preco);

            txtQuantidade.Clear();

            txtQuantidade.Focus();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            CalculaTotalItem();
        }

        async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                CalculaTotalItem();

                venda.idcliente = cboCliente.SelectedItem != null ? ((cliente)cboCliente.SelectedItem).id : 0;

                vendaitem item = new()
                {
                    idproduto = cboProduto.SelectedItem != null ? ((produto)cboProduto.SelectedItem).id : 0,
                    produto = cboProduto.SelectedItem != null ? ((produto)cboProduto.SelectedItem).nome : string.Empty,
                    quantidade = !Util.Nada(txtQuantidade.Text) ? Convert.ToDecimal(txtQuantidade.Text) : 0,
                    precounitario = cboProduto.SelectedItem != null ? ((produto)cboProduto.SelectedItem).preco : 0,
                    total = !Util.Nada(txtTotalItem.Text) ? Convert.ToDecimal(txtTotalItem.Text) : 0
                };

                await _vendaService.SalvarVenda(venda, item, _produtoService);

                AtualizaVendaLocal();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (venda == null) Close();
            }

            finally
            {
                cboProduto.SelectedIndex = -1;
                LimpaItem();
            }
        }
    }
}
