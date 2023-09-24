namespace WebMarket.Common.Messages
{
    public class GetCartProducts : IUserUid, ISupportOrdering
    {
        public Guid UserId { get; set; }
        public bool Descending { get; set; }
    }
}
