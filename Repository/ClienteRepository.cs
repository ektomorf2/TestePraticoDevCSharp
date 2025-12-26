using TestePraticoDevCSharp.Interfaces.Repository;
using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public async Task<cliente> Inserir(cliente cliente)
        {
            try
            {
                cliente.id = await Db.Insert(cliente);

                return cliente;
            } 
            
            catch (Exception e)
            { 
                throw new Exception(e.Message); 
            }
        }

        public async Task Atualizar(cliente cliente)
        {
            try
            {
                await Db.Update(cliente);
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
                await Db.Delete(new cliente { id = id });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>verifica se o email já existe para outro cliente</summary>
        public async Task<bool> VerificaEmail(cliente cliente)
        {
            try
            {
                cliente cli = await Db.Select(new cliente(), "", $"Id <> {cliente.id} And Email = {Db.VarChar(cliente.email)}");

                return cli != null && cli.id > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>verifica se já foi feita alguma venda para um determinado cliente.
        /// Verificação necessária antes de excluir o cliente</summary>
        public async Task<bool> VerificaVenda(int id)
        {
            try
            {
                return await Db.Existe(new venda(), "idcliente", id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<cliente>> Listar(string? nome = null)
        {
            try
            {
                return await Db.SelectList(new cliente(), null, nome != null ? Db.Like("Nome", nome) : "");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
