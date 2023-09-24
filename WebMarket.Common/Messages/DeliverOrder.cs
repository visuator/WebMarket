using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class DeliverOrder : StatusOrder
    {
        public override OrderStatus SetTo { get => OrderStatus.Delivered; }
    }
}
