using AutoMapper;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Domain.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderModel, CreateOrder>();
            CreateMap<GetUserOrdersModel, GetUserOrders>();
        }
    }
}
