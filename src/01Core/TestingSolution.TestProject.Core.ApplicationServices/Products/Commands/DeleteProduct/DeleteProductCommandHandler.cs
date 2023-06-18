using TestingSolution.TestProject.Core.Contracts.Products.Commands;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.DeleteProduct;

namespace TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IDeleteProductCommandHandler
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IDeleteProductCommandValidator _deleteProductCommandValidator;

        public DeleteProductCommandHandler(IProductCommandRepository productCommandRepository, IDeleteProductCommandValidator deleteProductCommandValidator)
        {
            _productCommandRepository = productCommandRepository;
            _deleteProductCommandValidator = deleteProductCommandValidator;
        }
        public void Execute(DeleteProductCommand command)
        {
            bool commandValid = _deleteProductCommandValidator.Validate(command);
            if (!commandValid)
            {
                throw new InvalidDataException("DeleteProductCommand invalid");
            }
            _productCommandRepository.DeleteProductById(command.ProductId);
        }
    }
}