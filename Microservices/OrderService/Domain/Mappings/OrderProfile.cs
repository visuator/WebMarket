using AutoMapper;

using OrderService.Entities;

using WebMarket.Common.Enums;
using WebMarket.Common.Messages;

namespace OrderService.Domain.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, GetOrderPackageInfoResult>();
            CreateMap<OrderProduct, GetOrderPackageInfoResult.OrderProductDto>();
            CreateMap<Product, GetOrderPackageInfoResult.ProductDto>();
            CreateMap<User, GetOrderPackageInfoResult.UserDto>();
            CreateMap<CreateOrder, Order>()
                .ForMember(x => x.Products, opt => opt.MapFrom(src => src.CartItemsIds.Select(x => new OrderProduct() { ProductId = x }).ToList()));
        }
    }
}
