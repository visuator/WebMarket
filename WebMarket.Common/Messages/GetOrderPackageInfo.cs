namespace WebMarket.Common.Messages
{
    public class GetOrderPackageInfo : IOrderUid
    {
        public Guid OrderId { get; set; }
    }
}
