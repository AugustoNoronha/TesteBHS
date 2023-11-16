using Microsoft.EntityFrameworkCore;
using TesteTecnicoBHS.Domain.Models;

namespace TesteTecnicoBHS.Infrastructure.Data.Context
{
    public class TesteBHSContext : DbContext
    {
        public TesteBHSContext(DbContextOptions<TesteBHSContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

    }
}
