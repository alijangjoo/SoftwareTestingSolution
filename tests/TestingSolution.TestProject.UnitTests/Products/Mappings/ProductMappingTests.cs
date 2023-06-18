using AutoMapper;
using System.Runtime.Serialization;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Mappings;
using TestingSolution.TestProject.Core.Domain.Products.Entities;
using Xunit;

namespace TestingSolution.TestProject.UnitTests.Products.Mappings
{
    public class ProductMappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public ProductMappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldBeValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(CreateProductCommand), typeof(Product))]
        [InlineData(typeof(Product), typeof(ProductResponseDto))]
        public void Map_SourceToDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);

            _mapper.Map(instance, origin, destination);
        }
    }
}