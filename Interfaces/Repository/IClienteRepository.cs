using TestePraticoDevCSharp.Models;

namespace TestePraticoDevCSharp.Interfaces.Repository
{
    public interface IClienteRepository 
    { 
        Task<cliente> Inserir(cliente cliente); 
        Task Atualizar(cliente cliente); 
        Task Excluir(int id);
        Task<bool> VerificaEmail(cliente cliente);
        Task<bool> VerificaVenda(int id);
        Task<List<cliente>> Listar(string? nome = null); 
    }
}
