namespace TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct
{
    public interface ICreateProductCommandValidator
    {
        bool Validate(CreateProductCommand command);
    }
}
