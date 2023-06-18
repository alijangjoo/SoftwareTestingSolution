using Bogus;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TestingSolution.TestProject.Core.Domain.Products.Entities;
using TestingSolution.TestProject.Infra.Data.SqlDb.Common;
using TestingSolution.TestProject.Infra.Tools.Utils;

namespace TestingSolutions.TestProject.IntegrationTests
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        private string dbName = "TestDatabase.db";

        public SharedDatabaseFixture()
        {
            Connection = new SqliteConnection($"Filename={dbName}");

            Seed();

            Connection.Open();
        }

        public DbConnection Connection { get; }

        public StoreDbContext CreateContext(DbTransaction? transaction = null)
        {
            var context = new StoreDbContext(new DbContextOptionsBuilder<StoreDbContext>().UseSqlite(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        SeedData(context);
                    }

                    _databaseInitialized = true;
                }
            }
        }

        private void SeedData(StoreDbContext context)
        {
            var productIds = 1;
            var fakeProducts = new Faker<Product>()
                .RuleFor(o => o.Name, f => $"Product {productIds}")
                .RuleFor(o => o.Description, f => $"Description {productIds}")
                .RuleFor(o => o.Id, f => productIds++)
                .RuleFor(o => o.Stock, f => f.Random.Number(1, 50))
                .RuleFor(o => o.Price, f => f.Random.Double(0.01, 100))
                .RuleFor(o => o.CreatedAt, f => DateUtil.GetCurrentDate())
                .RuleFor(o => o.UpdatedAt, f => DateUtil.GetCurrentDate());

            var products = fakeProducts.Generate(10);

            context.AddRange(products);

            context.SaveChanges();
        }

        public void Dispose() => Connection.Dispose();
    }
}