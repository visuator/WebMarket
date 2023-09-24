using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class GetCarrierOrdersResult
    {
        public List<OrderDto> Orders { get; set; }

        public class OrderDto
        {
            public Guid Id { get; set; }
            public OrderStatus Status { get; set; }
        }
    }
}
