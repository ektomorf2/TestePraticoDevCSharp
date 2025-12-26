using Npgsql;
using TestePraticoDevCSharp.Interfaces.Repository;
using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Service
{
    public class ProdutoService(IProdutoRepository repo) : IProdutoService
    {
        private readonly IProdutoRepository _repo = repo;

        void Validar(produto p)
        {
            string msg = string.Empty;

            if (Util.Nada(p.nome)) msg = $"{msg}Nome é obrigatório.\n";
            if (Util.Nada(p.descricao)) msg = $"{msg}Descrição é obrigatória.\n";
            if (p.preco <= 0) msg = $"{msg}Preço deve ser maior que zero.\n";
            if (p.estoque <= 0) msg = $"{msg}Estoque não pode ser negativo.\n";

            if (!Util.Nada(msg)) throw new Exception(msg);
        }

        public async Task<produto> Salvar(produto produto)
        {
            Validar(produto);

            if(produto.id == 0) produto = await _repo.Inserir(produto);

            else await _repo.Atualizar(produto);

            return produto;
        }

        public async Task<decimal> QuantidadeEmEstoque(int id)
        {
            return await _repo.QuantidadeEmEstoque(id);
        }

        public async Task AtualizaEstoque(NpgsqlConnection con, NpgsqlTransaction tran, int id, decimal quantidade, bool somaOuSubtrai)
        {
            await _repo.AtualizaEstoque(con, tran, id, quantidade, somaOuSubtrai);
        }

        public async Task Excluir(int id)
        {
            bool temVenda = await _repo.VerificaVenda(id);

            if (temVenda) throw new Exception("Produto possui vendas cadastradas e não pode ser excluído.");

            await _repo.Excluir(id);
        }

        public async Task<List<produto>> Listar(string? filtro = null)
        {
            return await _repo.Listar(filtro);
        }
    }
}
