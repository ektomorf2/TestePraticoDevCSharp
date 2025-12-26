using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp
{
    public partial class FrmProdutoConsulta : Form
    {
        private readonly IProdutoService _produtoService;

        public FrmProdutoConsulta(IProdutoService produtoService)
        {
            _produtoService = produtoService;
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

                List<produto> produtos = await _produtoService.Listar(txtConsulta.Text);

                if (!Util.ListOk(produtos) && informarNadaEncontrado)
                {
                    MessageBox.Show("Nenhum produto encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (produto produto in produtos.OrderBy(x => x.nome))
                {
                    grd.Rows.Add(
                    [
                        produto.id,
                        produto.nome,
                        produto.descricao,
                        produto.preco,
                        produto.estoque
                    ]);

                    grd.Rows[grd.RowCount - 1].Tag = produto;
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
            new FrmProdutoCadastro(_produtoService, new produto()).ShowDialog();
        }

        private async void grd_DoubleClick(object sender, EventArgs e)
        {
            if (grd.RowCount == 0) return;
            
            produto produto = (produto)grd.CurrentRow.Tag;

            new FrmProdutoCadastro(_produtoService, produto).ShowDialog();

            await Consultar(false);
        }
    }
}
