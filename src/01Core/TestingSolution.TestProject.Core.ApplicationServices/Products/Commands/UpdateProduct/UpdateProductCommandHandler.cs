using TestingSolution.TestProject.Core.Contracts.Products.Commands;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.UpdateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;

namespace TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IUpdateProductCommandHandler
    {
        private readonly IProductCommandRepository _productCommandRepository;

        public UpdateProductCommandHandler(IProductCommandRepository productCommandRepository)
        {
            _productCommandRepository = productCommandRepository;
        }
        public ProductResponseDto Execute(UpdateProductCommand command, int productId)
        {
            return _productCommandRepository.UpdateProduct(productId, command);
        }
    }
}