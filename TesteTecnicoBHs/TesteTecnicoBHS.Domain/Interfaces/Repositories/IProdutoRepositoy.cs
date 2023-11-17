using System.Net.Sockets;
using TesteTecnicoBHS.Domain.DataTransfer;
using TesteTecnicoBHS.Domain.Models;

namespace TesteTecnicoBHS.Domain.Interfaces.Repositories
{
    public interface IProdutoRepositoy
    {
        Task CreateProduto(ProdutoDataTransfer produtoDataTransfer);
        Task UpdateProduto(ProdutoDataTransfer produto, long id);
        Task<List<Produto>> GetAllProdutos();
        Task<List<Produto>> GetAllActiviteProdutos();
        Produto GetProdutoById(long id);
        Task DeletProduto(long id);

    }
}
