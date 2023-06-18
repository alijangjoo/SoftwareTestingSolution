using TestingSolution.TestProject.Core.Contracts.Products.Commands;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;

namespace TestingSolution.TestProject.Core.ApplicationServices.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ICreateProductCommandHandler
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly ICreateProductCommandValidator _createProductCommandValidator;

        public CreateProductCommandHandler(IProductCommandRepository productCommandRepository, ICreateProductCommandValidator createProductCommandValidator)
        {
            _productCommandRepository = productCommandRepository;
            _createProductCommandValidator = createProductCommandValidator;
        }
        public ProductResponseDto Execute(CreateProductCommand command)
        {
            var validateResult = _createProductCommandValidator.Validate(command);
            if (!validateResult)
                throw new InvalidDataException("CreateProductCommand is invalid");

            var product = _productCommandRepository.CreateProduct(command);
            return product;
        }
    }
}