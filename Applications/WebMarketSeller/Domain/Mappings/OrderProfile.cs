using AutoMapper;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Domain.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<GetOrdersModel, GetUserOrders>();
        }
    }
}
