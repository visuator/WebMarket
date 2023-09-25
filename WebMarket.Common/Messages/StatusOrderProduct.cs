using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public abstract class StatusOrderProduct : IOrderUid
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public abstract OrderProductStatus SetTo { get; }
    }
}
