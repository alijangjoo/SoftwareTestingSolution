using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TestingSolution.TestProject.Core.Domain.Products.Entities;

namespace TestingSolution.TestProject.Infra.Data.SqlDb.Common
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Product> Products { get; set; }
    }

    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            optionBuilder.UseSqlServer("Server =.; Database=StoreTest;User Id = sa;Password=1qaz!QAZ; MultipleActiveResultSets=true; Encrypt = false");
            return new StoreDbContext(optionBuilder.Options);
        }
    }
}