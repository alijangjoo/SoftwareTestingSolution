using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;

namespace TestingSolution.TestProject.Core.Contracts.Products.Commands.DeleteProduct
{
    public interface IDeleteProductCommandHandler
    {
        void Execute(DeleteProductCommand command);
    }
}
