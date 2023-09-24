using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class BuildOrder : StatusOrder
    {
        public override OrderStatus SetTo { get => OrderStatus.Built; }
    }
}
