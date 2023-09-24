namespace WebMarket.Common.Messages
{
    public class GetBrands : IUserUid, ISupportOrdering
    {
        public bool Descending { get; set; }
        public Guid UserId { get; set; }
    }
}
