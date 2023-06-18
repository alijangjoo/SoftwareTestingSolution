using TestingSolution.TestProject.Core.Contracts.Products.Commands.DeleteProduct;

namespace TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : IDeleteProductCommandValidator
    {
        public bool Validate(DeleteProductCommand command)
        {
            if (command.ProductId <= 0)
                return false;
            
            else return true;
        }
    }
}