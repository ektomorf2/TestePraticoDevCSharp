using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp.Interfaces.Service
{
    public interface IClienteService
    {
        Task<cliente> Salvar(cliente c);
        Task Excluir(int id);
        Task<bool> VerificaEmail(cliente c);
        Task<List<cliente>> Listar(string? nomeFiltro = null);
    }
}
