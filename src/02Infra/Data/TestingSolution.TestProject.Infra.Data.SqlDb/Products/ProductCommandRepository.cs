using AutoMapper;
using TestingSolution.TestProject.Core.Contracts.Common.Exceptions;
using TestingSolution.TestProject.Core.Contracts.Products.Commands;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.UpdateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;
using TestingSolution.TestProject.Core.Domain.Products.Entities;
using TestingSolution.TestProject.Infra.Data.SqlDb.Common;
using TestingSolution.TestProject.Infra.Tools.Utils;

namespace TestingSolution.TestProject.Infra.Data.SqlDb.Products
{
    public partial class ProductCommandRepository : IProductCommandRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly IMapper _mapper;

        public ProductCommandRepository(StoreDbContext storeDbContext, IMapper mapper)
        {
            _storeDbContext = storeDbContext;
            _mapper = mapper;
        }
        public ProductResponseDto CreateProduct(CreateProductCommand request)
        {
            var product = _mapper.Map<Product>(request);
            product.Stock = 0;
            product.CreatedAt = product.UpdatedAt = DateUtil.GetCurrentDate();

            _storeDbContext.Products.Add(product);
            _storeDbContext.SaveChanges();

            return _mapper.Map<ProductResponseDto>(product);
        }

        public void DeleteProductById(int productId)
        {
            var product = _storeDbContext.Products.Find(productId);
            if (product != null)
            {
                _storeDbContext.Products.Remove(product);
                _storeDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public ProductResponseDto UpdateProduct(int productId, UpdateProductCommand request)
        {
            var product = _storeDbContext.Products.Find(productId);
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.UpdatedAt = DateUtil.GetCurrentDate();

                _storeDbContext.Products.Update(product);
                _storeDbContext.SaveChanges();

                return _mapper.Map<ProductResponseDto>(product);
            }

            throw new NotFoundException();
        }
    }
}