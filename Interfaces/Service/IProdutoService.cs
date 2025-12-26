using Npgsql;
using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp.Interfaces.Service
{
    public interface IProdutoService
    {
        Task<produto> Salvar(produto p);
        Task<decimal> QuantidadeEmEstoque(int id);
        Task AtualizaEstoque(NpgsqlConnection con, NpgsqlTransaction tran, int id, decimal quantidade, bool somaOuSubtrai);
        Task Excluir(int id);
        Task<List<produto>> Listar(string? filtro = null);
    }
}
