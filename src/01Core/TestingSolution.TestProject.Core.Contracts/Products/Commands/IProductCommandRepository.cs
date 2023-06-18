using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.UpdateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;

namespace TestingSolution.TestProject.Core.Contracts.Products.Commands
{
    public interface IProductCommandRepository
    {
        void DeleteProductById(int productId);

        ProductResponseDto CreateProduct(CreateProductCommand request);

        ProductResponseDto UpdateProduct(int productId, UpdateProductCommand request);
    }
}