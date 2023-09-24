namespace WebMarket.Common.Messages
{
    public class GetOrderStatus : IOrderUid
    {
        public Guid OrderId { get; set; }
    }
}
