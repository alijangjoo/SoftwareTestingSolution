using TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.DeleteProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.DeleteProduct;
using TestingSolution.TestProject.Infra.Data.SqlDb.Products;

namespace TestingSolutions.TestProject.IntegrationTests
{
    public class ProductCommandFactory
    {
        public static ICreateProductCommandHandler GenerateCreateProductCommandHandler(ProductCommandRepository productCommandRepository)
        {
            ICreateProductCommandValidator createProductCommandValidator = new CreateProductCommandValidator();
            ICreateProductCommandHandler createProductCommandHandler = new CreateProductCommandHandler(productCommandRepository, createProductCommandValidator);
            return createProductCommandHandler;
        }

        public static IDeleteProductCommandHandler GenerateDeleteProductCommandHandler(ProductCommandRepository productCommandRepository)
        {
            IDeleteProductCommandValidator deleteProductCommandValidator = new DeleteProductCommandValidator();
            IDeleteProductCommandHandler deleteProductCommandHandler = new DeleteProductCommandHandler(productCommandRepository, deleteProductCommandValidator);
            return deleteProductCommandHandler;
        }
    }
}