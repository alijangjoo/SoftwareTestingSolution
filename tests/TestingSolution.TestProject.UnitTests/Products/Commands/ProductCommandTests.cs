using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.UpdateProduct;
using TestingSolution.TestProject.UnitTests.Common;
using Xunit;

namespace TestingSolution.TestProject.UnitTests.Products.Commands
{
    public class ProductCommandTests : BaseTests
    {
        [Theory]
        [InlineData("Test", "Description", 0.02, 0)]
        [InlineData("Test", null, 0.02, 1)]
        [InlineData(null, null, 0.02, 2)]
        [InlineData(null, null, -1, 3)]
        public void ValidateModel_CreateProductRequest_ReturnsCorrectNumberOfErrors(string name, string description, double price, int numberExpectedErrors)
        {
            var request = new CreateProductCommand
            {
                Name = name,
                Description = description,
                Price = price
            };

            var errorList = ValidateModel(request);

            Assert.Equal(numberExpectedErrors, errorList.Count);
        }

        [Theory]
        [InlineData("Test", "Description", 0.02, 4, 0)]
        [InlineData("Test", null, 0.02, 9, 1)]
        [InlineData(null, null, 0.02, 1, 2)]
        [InlineData(null, null, -1, 8, 3)]
        [InlineData(null, null, -1, 200, 4)]
        public void ValidateModel_UpdateProductRequest_ReturnsCorrectNumberOfErrors(string name, string description, double price, int stock, int numberExpectedErrors)
        {
            var request = new UpdateProductCommand
            {
                Name = name,
                Description = description,
                Price = price,
                Stock = stock
            };

            var errorList = ValidateModel(request);

            Assert.Equal(numberExpectedErrors, errorList.Count);
        }

    }
}