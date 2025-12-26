using Npgsql;
using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task<produto> Inserir(produto p); 
        Task Atualizar(produto p);
        Task Excluir(int id);
        Task<decimal> QuantidadeEmEstoque(int id);
        Task AtualizaEstoque(NpgsqlConnection con, NpgsqlTransaction tran, int id, decimal quantidade, bool somaOuSubtrai);
        Task<bool> VerificaVenda(int id);
        Task<produto?> BuscarPorId(int id); 
        Task<List<produto>> Listar(string? nomeFiltro = null);
    }
}
