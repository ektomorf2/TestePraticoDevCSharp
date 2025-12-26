using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp.Interfaces.Repository
{
    public interface IVendaRepository
    {
        Task<venda> SalvarVenda(venda venda, vendaitem item, IProdutoService produtoService);

        Task ExcluirVenda(venda venda, IProdutoService produtoService);

        Task<List<venda>> ListarVenda(venda venda);

        Task<List<vendaitem>> ListarItem(int id);
    }
}
