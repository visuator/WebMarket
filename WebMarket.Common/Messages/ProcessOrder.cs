using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class ProcessOrder : StatusOrder
    {
        public override OrderStatus SetTo { get => OrderStatus.Proccessing; }
    }
}
