namespace WebMarket.Common.Messages
{
    public class GetSellerOrders : IUserUid, ISupportOrdering
    {
        public bool Descending { get; set; }
        public Guid UserId { get; set; }
    }
}
