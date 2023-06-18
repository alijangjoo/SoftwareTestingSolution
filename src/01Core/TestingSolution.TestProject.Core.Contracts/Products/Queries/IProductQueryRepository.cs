using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;

namespace TestingSolution.TestProject.Core.Contracts.Products.Queries
{
    public interface IProductQueryRepository
    {
        List<ProductResponseDto> GetProducts();

        ProductResponseDto GetProductById(int productId);
    }
}