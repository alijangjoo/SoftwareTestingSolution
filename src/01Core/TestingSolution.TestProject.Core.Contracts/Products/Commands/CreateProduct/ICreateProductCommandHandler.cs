using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;

namespace TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct
{
    public interface ICreateProductCommandHandler
    {
        ProductResponseDto Execute(CreateProductCommand command);
    }
}