using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.DeleteProduct;
using TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.UpdateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.DeleteProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.UpdateProduct;

namespace TestingSolution.TestProject.Core.ApplicationServices
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductCommandHandler, CreateProductCommandHandler>();
            services.AddScoped<ICreateProductCommandValidator, CreateProductCommandValidator>();

            services.AddScoped<IUpdateProductCommandHandler, UpdateProductCommandHandler>();

            services.AddScoped<IDeleteProductCommandHandler, DeleteProductCommandHandler>();
            services.AddScoped<IDeleteProductCommandValidator, DeleteProductCommandValidator>();

            return services;
        }
    }
}