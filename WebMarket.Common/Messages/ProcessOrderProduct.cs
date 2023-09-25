using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class ProcessOrderProduct : StatusOrderProduct
    {
        public override OrderProductStatus SetTo { get => OrderProductStatus.Proccessing; }
    }
}
