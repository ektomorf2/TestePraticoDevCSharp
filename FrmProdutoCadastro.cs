using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp
{
    public partial class FrmProdutoCadastro : Form
    {
        private readonly IProdutoService _produtoService;
        produto produto;

        public FrmProdutoCadastro(IProdutoService produtoService, produto p)
        {
            InitializeComponent();

            _produtoService = produtoService;

            produto = p;

            if (produto != null && produto.id > 0)
            {
                txtId.Text = produto.id > 0 ? Convert.ToString(produto.id) : "";
                txtNome.Text = produto.nome;
                txtDescricao.Text = produto.descricao;
                txtPreco.Text = Convert.ToString(produto.preco);
                txtEstoque.Text = Convert.ToString(produto.estoque);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtEstoque.Clear();
            txtNome.Focus();
        }

        async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                produto.id = Util.Nada(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
                produto.nome = txtNome.Text;
                produto.descricao = txtDescricao.Text;
                produto.preco = !Util.Nada(txtPreco.Text) ? Convert.ToDecimal(txtPreco.Text) : 0;
                produto.estoque = !Util.Nada(txtEstoque.Text) ? Convert.ToDecimal(txtEstoque.Text) : 0;

                await _produtoService.Salvar(produto);

                txtId.Text = Convert.ToString(produto.id);

                MessageBox.Show("Dados Salvos com Sucesso!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = sender as TextBox; 
            
            if (char.IsControl(e.KeyChar)) return; 
            
            if (char.IsDigit(e.KeyChar)) return; 
            
            if (e.KeyChar == ',' || e.KeyChar == '.') {
                if (tb.Text.Contains(',') || tb.Text.Contains('.')) e.Handled = true; 
                else return;
            }
            
            e.Handled = true;
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = sender as TextBox;

            if (char.IsControl(e.KeyChar)) return;

            if (char.IsDigit(e.KeyChar)) return;

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (tb.Text.Contains(',') || tb.Text.Contains('.')) e.Handled = true;

                else return;
            }

            e.Handled = true;
        }

        async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (produto.id == 0) return;
            
            if (MessageBox.Show("Confirma a exclusão do produto?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            try
            {
                await _produtoService.Excluir(produto.id);

                MessageBox.Show("Produto excluído com sucesso!", "Excluir Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Excluir Produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
