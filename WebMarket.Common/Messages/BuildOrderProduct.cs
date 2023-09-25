using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class BuildOrderProduct : StatusOrderProduct
    {
        public override OrderProductStatus SetTo { get => OrderProductStatus.Built; }
    }
}
