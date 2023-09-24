namespace WebMarket.Common.Messages
{
    public class GetUserOrders : IUserUid, ISupportOrdering
    {
        public bool Descending { get; set; }
        public Guid UserId { get; set; }
    }
}
