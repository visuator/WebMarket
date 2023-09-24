using AutoMapper;

using OrderService.Entities;

using WebMarket.Common.Messages;

namespace OrderService.Domain.Mappings
{
    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProduct, GetOrdersResult.OrderProductDto>();
        }
    }
}
