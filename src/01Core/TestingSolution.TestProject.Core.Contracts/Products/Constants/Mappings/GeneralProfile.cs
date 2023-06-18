using AutoMapper;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;
using TestingSolution.TestProject.Core.Domain.Products.Entities;

namespace TestingSolution.TestProject.Core.Contracts.Products.Constants.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.Stock,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.CreatedAt,
                    opt => opt.Ignore()
                )
                .ForMember(dest =>
                    dest.UpdatedAt,
                    opt => opt.Ignore()
                );

            CreateMap<Product, ProductResponseDto>();
        }
    }
}