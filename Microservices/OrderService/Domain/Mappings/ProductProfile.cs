using AutoMapper;

using OrderService.Entities;

using WebMarket.Common.Messages;

namespace OrderService.Domain.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetOrdersResult.ProductDto>();
            CreateMap<ProductCreated, Product>();
        }
    }
}
