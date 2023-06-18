using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;

namespace TestingSolution.TestProject.Core.Contracts.Products.Commands.UpdateProduct
{
    public interface IUpdateProductCommandHandler
    {
        ProductResponseDto Execute(UpdateProductCommand command, int productId);
    }
}