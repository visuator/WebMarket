using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class ReceiveOrder : StatusOrder
    {
        public override OrderStatus SetTo { get => OrderStatus.Received; }
    }
}
