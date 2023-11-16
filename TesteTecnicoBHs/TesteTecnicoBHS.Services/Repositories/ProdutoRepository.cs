using Microsoft.EntityFrameworkCore;
using TesteTecnicoBHS.Domain.DataTransfer;
using TesteTecnicoBHS.Domain.Interfaces;
using TesteTecnicoBHS.Domain.Models;
using TesteTecnicoBHS.Infrastructure.Data.Context;

namespace TesteTecnicoBHS.Services.Repositories
{
    public class ProdutoRepository : IProdutoRepositoy
    {

        private readonly TesteBHSContext _context;
        public ProdutoRepository(TesteBHSContext context)
        {
            _context = context;
        }
        public async Task CreateProduto(ProdutoDataTransfer produtoDataTransfer)
        {
            Produto addProduto = new Produto { 
                Nome = produtoDataTransfer.Nome , 
                Status = produtoDataTransfer.Status 
            };

            await _context.Produtos.AddAsync(addProduto);
            _context.SaveChanges();
        }

        public async Task DeletProduto(long id)
        {
            Produto produto = GetProdutoById(id);
            if (produto != null)
            {
                await _context.Produtos.Where(e => e.Id == id).ExecuteDeleteAsync();
                _context.SaveChanges();
            }
        }

        public async Task<List<Produto>> GetAllProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<List<Produto>> GetAllActiviteProdutos()
        {
            return await _context.Produtos.Where(e => e.Status == true).ToListAsync();
        }

        public Produto GetProdutoById(long id)
        {
            return _context.Produtos.Where(e => e.Id == id).FirstOrDefault();
        }

        public async Task UpdateProduto(ProdutoDataTransfer produto, long id)
        {
            Produto prod = GetProdutoById(id);
            if (produto != null)
            {
                await _context.Produtos.Where(e => e.Id == id)
              .ExecuteUpdateAsync(
                  setter => setter.SetProperty(b => b.Nome, produto.Nome)
                  .SetProperty(b => b.Status, produto.Status)
                  );
                _context.SaveChanges();
            }
        }
    }
}
