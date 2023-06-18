using AutoMapper;
using TestingSolution.TestProject.Core.Contracts.Common.Exceptions;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.DeleteProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Mappings;
using TestingSolution.TestProject.Infra.Data.SqlDb.Products;

namespace TestingSolutions.TestProject.IntegrationTests.Products.Commands.DeleteCommand
{
    public class DeleteProductCommandTest : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private SharedDatabaseFixture Fixture { get; }

        public DeleteProductCommandTest(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(102)]
        public void DeleteProductById_ProductDoesntExist_ThrowsNotFoundException(int productId)
        {
            using (var context = Fixture.CreateContext())
            {

                var deleteProductCommand = new DeleteProductCommand()
                {
                    ProductId = productId
                };

                var repository = new ProductCommandRepository(context, _mapper);
                var deleteProductCommandHandler = ProductCommandFactory.GenerateDeleteProductCommandHandler(repository);
                Assert.Throws<NotFoundException>(() => deleteProductCommandHandler.Execute(deleteProductCommand));
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void DeleteProductById_InvalidInput_ThrowsInvalidDataException(int productId)
        {
            using (var context = Fixture.CreateContext())
            {

                var deleteProductCommand = new DeleteProductCommand()
                {
                    ProductId = productId
                };

                var repository = new ProductCommandRepository(context, _mapper);
                var deleteProductCommandHandler = ProductCommandFactory.GenerateDeleteProductCommandHandler(repository);
                Assert.Throws<InvalidDataException>(() => deleteProductCommandHandler.Execute(deleteProductCommand));
            }
        }
    }
}