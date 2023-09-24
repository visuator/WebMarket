using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class ReturnOrder : StatusOrder
    {
        public override OrderStatus SetTo { get => OrderStatus.Returned; }
    }
}
