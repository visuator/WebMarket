using AutoMapper;

using ProductService.Entities;

using WebMarket.Common.Messages;

namespace ProductService.Domain.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProduct, Product>();
            CreateMap<Product, FindProductsResult.ProductDto>();
            CreateMap<Product, ProductCreated>();
        }
    }
}
