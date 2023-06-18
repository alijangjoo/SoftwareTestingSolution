namespace TestingSolution.TestProject.Core.Contracts.Products.Commands.DeleteProduct
{
    public interface IDeleteProductCommandValidator
    {
        bool Validate(DeleteProductCommand command);
    }
}
