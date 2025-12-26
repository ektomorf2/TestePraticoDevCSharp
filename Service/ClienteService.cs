using TestePraticoDevCSharp.Interfaces.Repository;
using TestePraticoDevCSharp.Interfaces.Service;
using TestePraticoDevCSharp.Models;
using TestePraticoDevCSharp.Utils;

namespace TestePraticoDevCSharp.Service
{
    public class ClienteService(IClienteRepository repo) : IClienteService
    {
        public readonly IClienteRepository _repo = repo;

        public async Task<bool> VerificaEmail(cliente c)
        {
            return await _repo.VerificaEmail(c);
        }

        async Task Validar(cliente c)
        {
            string msg = string.Empty;

            if (Util.Nada(c.nome)) msg = $"{msg}Nome é obrigatório.\n";
            if (Util.Nada(c.email)) msg = $"{msg}E-mail é obrigatório.\n";

            if (!Util.Nada(msg)) throw new Exception(msg);

            bool emailExiste = await VerificaEmail(c);

            if (emailExiste) throw new Exception("E-mail já cadastrado.");
        }

        public async Task<cliente> Salvar(cliente cliente)
        {
            await Validar(cliente);

            if(cliente.id == 0) cliente = await _repo.Inserir(cliente);

            else await _repo.Atualizar(cliente);

            return cliente;
        }

        public async Task Excluir(int id)
        {
            bool temVenda = await _repo.VerificaVenda(id);

            if (temVenda) throw new Exception("Cliente possui vendas cadastradas e não pode ser excluído.");

            await _repo.Excluir(id);
        }
            

        public async Task<List<cliente>> Listar(string? filtro)
        {
            return await _repo.Listar(filtro);
        }
    }
}
