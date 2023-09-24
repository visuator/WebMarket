namespace WebMarket.Common.Messages
{
    public class AddToCart : IUserUid
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
