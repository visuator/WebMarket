using AutoMapper;

using WebMarket.Common.Messages;

using WebMarketDelivery.Models;

namespace WebMarketDelivery.Domain.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<GetCarrierOrdersModel, GetCarrierOrders>();
        }
    }
}
