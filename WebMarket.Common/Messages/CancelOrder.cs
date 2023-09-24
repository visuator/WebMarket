using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class CancelOrder : StatusOrder
    {
        public override OrderStatus SetTo { get => OrderStatus.Canceled; }
    }
}
