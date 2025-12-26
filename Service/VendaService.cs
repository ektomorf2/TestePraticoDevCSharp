using TestePraticoDevCSharp.Interfaces.Repository;
using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Service
{
    public class VendaService(IVendaRepository repo, IProdutoService produtoService) : IVendaService
    {
        private readonly IVendaRepository _repo = repo;
        private readonly IProdutoService _produtoService = produtoService;

        public async Task<venda> SalvarVenda(venda venda, vendaitem item, IProdutoService produtoService)
        {
            string msg = string.Empty;

            if (venda.idcliente <= 0)msg = $"{msg}Selecione um Cliente.\n";

            if(item == null || item.idproduto == 0) msg = $"{msg}Selecione um Produto.\n";
            
            if(item == null || item.quantidade <= 0) msg = $"{msg}Quantidade deve ser maior que zero.\n";

            if (Util.ListOk(venda.itens) && venda.itens.Where(i => i.idproduto == item.idproduto).Any()) msg = $"{msg}O Produto selecionado já foi adicionado na venda.\n";

            if(!Util.Nada(msg)) throw new Exception(msg);

            decimal estoqueProduto = await _produtoService.QuantidadeEmEstoque(item.idproduto);

            if (estoqueProduto - item.quantidade < 0)
            {
                if (venda.id > 0) await _repo.ExcluirVenda(venda, produtoService);

                venda = null;

                throw new Exception($"Estoque insuficiente para o produto selecionado.\nQtde. informada: {item.quantidade}.\nQtde. em estoque: {estoqueProduto}.\n\nA venda foi cancelada.");
            }

            venda.total += item.total;

            venda.datahora = DateTime.Now;

            venda = await _repo.SalvarVenda(venda,item,produtoService);

            venda.itens.Add(item);

            return venda;
        }

        public Task ExcluirVenda(venda venda, vendaitem item, IProdutoService produtoService)
        {
            throw new NotImplementedException();
        }

        public decimal CalculaTotalItem(decimal preco, decimal quantidade)
        {
            if (quantidade <= 0 || preco <= 0) return 0;

            return preco * quantidade;
        }

        public async Task<List<venda>> ListarVenda(venda venda)
        {
            return await _repo.ListarVenda(venda);
        }

        public async Task<List<vendaitem>> ListarItem(int idVenda)
        {
            return await _repo.ListarItem(idVenda);
        }
    }
}
