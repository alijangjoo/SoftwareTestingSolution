using AutoMapper;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Mappings;
using TestingSolution.TestProject.Infra.Data.SqlDb.Products;

namespace TestingSolutions.TestProject.IntegrationTests.Products.Commands.CreateCommand
{
    public class CreateProductCommandTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private SharedDatabaseFixture Fixture { get; }

        public CreateProductCommandTests(SharedDatabaseFixture fixture)
        {
            Fixture = fixture;

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });

            _mapper = configuration.CreateMapper();
        }

        [Theory]
        [InlineData("", "", 10)]
        [InlineData("Keyboard", "", 10)]
        [InlineData("", "Keyboard description", 10)]
        public void CreateProduct_InputInvalid_ThrowInvalidDataException(string name, string description, double price)
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    var command = new CreateProductCommand()
                    {
                        Name = name,
                        Description = description,
                        Price = price
                    };

                    var repository = new ProductCommandRepository(context, _mapper);
                    var createProductCommandHandler = ProductCommandFactory.GenerateCreateProductCommandHandler(repository);
                    Assert.Throws<InvalidDataException>(() => createProductCommandHandler.Execute(command));
                }
            }
        }
    }
}