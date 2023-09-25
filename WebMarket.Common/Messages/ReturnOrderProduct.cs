using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class ReturnOrderProduct : StatusOrderProduct
    {
        public override OrderProductStatus SetTo { get => OrderProductStatus.Returned; }
    }
}
