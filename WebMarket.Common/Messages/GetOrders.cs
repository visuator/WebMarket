namespace WebMarket.Common.Messages
{
    public class GetOrders : IUserUid, ISupportOrdering
    {
        public bool Descending { get; set; }
        public Guid UserId { get; set; }
    }
}
