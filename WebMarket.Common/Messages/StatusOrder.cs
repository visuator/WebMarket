using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public abstract class StatusOrder : IOrderUid
    {
        public abstract OrderStatus SetTo { get; }
        public Guid OrderId { get; set; }
    }
}
