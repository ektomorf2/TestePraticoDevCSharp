using Npgsql;
using TestePraticoDevCSharp.Interfaces.Repository;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public async Task<produto> Inserir(produto p)
        {
            try
            {
                p.id = await Db.Insert(p);

                return p;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Atualizar(produto p)
        {
            try
            {
                await Db.Update(p);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>verifica se já foi feita alguma venda de um determinado produto.
        /// Verificação necessária antes de excluir o produto</summary>
        public async Task<bool> VerificaVenda(int id)
        {
            try
            {
                return await Db.Existe(new vendaitem(), "idproduto", id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task Excluir(int id)
        {
            try
            {
                await Db.Delete(new produto { id = id});
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<produto?> BuscarPorId(int id)
        {
            try
            {
                return await Db.Select(new produto(), null, $"Id={id}");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>retorna a quantidade em estoque atual de um produto</summary>
        public async Task<decimal> QuantidadeEmEstoque(int id)
        {
            try
            {
                produto p = await Db.Select(new produto(), "estoque", $"Id={id}");

                return p.estoque;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>atualiza a quantidade de estoque do produto, sempre que um item for 
        /// inserido ou removido da venda. O parâmetro somaOuSubtrai: quando true, soma a quantidade
        /// ao estoque atual, quando false, subtrai a quantidade do estoque atual</summary>
        public async Task AtualizaEstoque(NpgsqlConnection con, NpgsqlTransaction tran, int id, decimal quantidade, bool somaOuSubtrai)
        {
            try
            {
                decimal estoqueAtual = await QuantidadeEmEstoque(id);

                produto produto = new()
                {
                    id = id,
                    estoque = somaOuSubtrai ? estoqueAtual + quantidade : estoqueAtual - quantidade
                };

                await Db.UpdateCustomTran(con,tran,produto, "estoque");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<produto>> Listar(string? filtro = null)
        {
            try
            {
                return await Db.SelectList(new produto(), null, !Util.Nada(filtro)
                    ? $"{Db.Like("nome",filtro)} Or {Db.Like("descricao", filtro)}" : "");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
