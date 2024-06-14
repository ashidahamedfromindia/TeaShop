using AutoMapper;
using TeaShop.Domain.Dtos;
using TeaShop.Domain.Entities;

namespace TeaShop.Application.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();

            CreateMap<AllProducts, AllProductsDto>().ReverseMap();
            CreateMap<AllProductsDto, ProductListWithCategoryDto>().ReverseMap();
            CreateMap<AllProductWithClassificationDto, AllProductsDto>().ReverseMap();

            CreateMap<CustomerOrder, CustomerOrderDto>().ReverseMap();
            CreateMap<CustomerOrderDto, CustomerOrderforPostDto>().ReverseMap();

        }
    }
}
