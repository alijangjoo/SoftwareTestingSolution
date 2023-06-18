using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TestingSolution.TestProject.Core.Contracts.Products.Commands;
using TestingSolution.TestProject.Core.Contracts.Products.Queries;
using TestingSolution.TestProject.Infra.Data.SqlDb.Common;
using TestingSolution.TestProject.Infra.Data.SqlDb.Products;

namespace TestingSolution.TestProject.Infra.Data.SqlDb
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddStoreInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoreDbContext>(options =>
               options.UseSqlServer(defaultConnectionString));

            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();

            var serviceProvider = services.BuildServiceProvider();
            try
            {
                var dbContext = serviceProvider.GetRequiredService<StoreDbContext>();
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
            }

            return services;
        }
    }
}