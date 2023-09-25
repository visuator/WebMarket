using AutoMapper;

using OrderService.Entities;

using WebMarket.Common.Messages;

namespace OrderService.Domain.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderCreated.OrderDto>();
            CreateMap<Order, GetUserOrdersResult.OrderDto>();
            CreateMap<Order, GetCarrierOrdersResult.OrderDto>();
            CreateMap<Order, GetOrderPackageInfoResult.OrderDto>();
            CreateMap<Order, GetSellerOrdersResult.OrderDto>();
            CreateMap<CreateOrder, Order>()
                .ForMember(x => x.Products, opt => opt.MapFrom(src => src.CartItemsIds.Select(x => new OrderProduct() { ProductId = x }).ToList()));
        }
    }
}
