using AutoMapper;

using CartService.Entities;

using WebMarket.Common.Messages;

namespace CartService.Domain.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddToCart, UserProduct>();
            CreateMap<UserProduct, GetCartProductsResult.UserProductDto>();
            CreateMap<User, GetCartProductsResult.UserDto>();
            CreateMap<Product, GetCartProductsResult.ProductDto>();
        }
    }
}
