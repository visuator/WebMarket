namespace WebMarket.Common.Messages
{
    public class GetCategories : IUserUid, ISupportOrdering
    {
        public bool Descending { get; set; }
        public Guid UserId { get; set; }
    }
}
