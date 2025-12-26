using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp.Interfaces.Service
{
    public interface IVendaService
    {
        Task<venda> SalvarVenda(venda venda, vendaitem item, IProdutoService produtoService);

        Task ExcluirVenda(venda venda, vendaitem item, IProdutoService produtoService);

        Task<List<venda>> ListarVenda(venda venda);

        Task<List<vendaitem>> ListarItem(int idVenda);

        decimal CalculaTotalItem(decimal preco, decimal quantidade);
    }
}
