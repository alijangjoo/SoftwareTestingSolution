using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;

namespace TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : ICreateProductCommandValidator
    {
        public bool Validate(CreateProductCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Description) || string.IsNullOrWhiteSpace(command.Name))
            {
                return false;
            }
            return true;
        }
    }
}