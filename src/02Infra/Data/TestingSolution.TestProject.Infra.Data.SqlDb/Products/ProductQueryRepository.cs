using AutoMapper;
using TestingSolution.TestProject.Core.Contracts.Common.Exceptions;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;
using TestingSolution.TestProject.Core.Contracts.Products.Queries;
using TestingSolution.TestProject.Infra.Data.SqlDb.Common;

namespace TestingSolution.TestProject.Infra.Data.SqlDb.Products
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly IMapper _mapper;

        public ProductQueryRepository(StoreDbContext storeDbContext, IMapper mapper)
        {
            _storeDbContext = storeDbContext;
            _mapper = mapper;
        }
        public ProductResponseDto GetProductById(int productId)
        {
            var product = _storeDbContext.Products.Find(productId);
            if (product != null)
            {
                return _mapper.Map<ProductResponseDto>(product);
            }

            throw new NotFoundException();
        }

        public List<ProductResponseDto> GetProducts()
        {
            return _storeDbContext.Products.Select(p => _mapper.Map<ProductResponseDto>(p)).ToList();
        }
    }
}