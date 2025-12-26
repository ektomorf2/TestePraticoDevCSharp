using Npgsql;
using TestePraticoDevCSharp.Interfaces.Repository;
using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp.Repository
{
    public class VendaRepository : IVendaRepository
    {
        public async Task<venda> SalvarVenda(venda venda, vendaitem item, IProdutoService produtoService)
        {
            NpgsqlConnection con = new();
            NpgsqlTransaction? tran = null;

            try
            {
                (con,tran) = await Db.ConectarComTransacao();

                if(venda.id == 0) venda.id = await Db.InsertTran(con, tran, venda);

                else await Db.UpdateTran(con, tran, venda);

                item.idvenda = venda.id;

                item.id = await Db.InsertTran(con, tran, item);

                await produtoService.AtualizaEstoque(con, tran, item.idproduto, item.quantidade, false);

                await tran.CommitAsync();

                return venda;
            }
            catch (Exception e)
            {
                if(tran != null) await tran.RollbackAsync();
                throw new Exception(e.Message);
            }
            finally
            {
                if(tran != null) await tran.DisposeAsync();
                await con.DisposeAsync();
            }
        }

        public async Task ExcluirVenda(venda venda,IProdutoService produtoService)
        {
            NpgsqlConnection con = new();
            NpgsqlTransaction? tran = null;

            try
            {
                (con, tran) = await Db.ConectarComTransacao();

                foreach (vendaitem i in venda.itens)
                {
                    await Db.DeleteTran(con, tran, i);
                    await produtoService.AtualizaEstoque(con, tran, i.idproduto, i.quantidade, true);
                }

                await Db.DeleteTran(con, tran, venda);

                await tran.CommitAsync();
            }
            catch (Exception e)
            {
                if (tran != null) await tran.RollbackAsync();
                throw new Exception(e.Message);
            }
            finally
            {
                if (tran != null) await tran.DisposeAsync();
                await con.DisposeAsync();
            }
        }

        public async Task<List<venda>> ListarVenda(venda venda)
        {
            try
            {
                string sql = string.Concat(
                    "v.id, v.datahora, v.total,\n",
                    "v.idcliente, c.nome as cliente\n",
                    "From venda v\n",
                    "Inner Join cliente c On v.idcliente = c.id\n"
                );

                sql = venda.idcliente > 0
                    ? string.Concat(sql, $"Where v.idcliente={venda.idcliente}\n")
                    : sql;

                sql = Db.BetweenDate(sql,"v.datahora",venda.dataIni,venda.dataFim);

                return await Db.SelectList(new venda(), sql);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<vendaitem>> ListarItem(int idvenda)
        {
            try
            {
                string sql = string.Concat(
                    "i.id, i.idvenda, i.precounitario, i.quantidade, i.total,\n",
                    "i.idproduto, p.nome as produto\n",
                    "From vendaitem i\n",
                    "Inner Join produto p On i.idproduto = p.id\n",
                    $"Where i.idvenda = {idvenda}"
                );

                return await Db.SelectList(new vendaitem(), sql);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
