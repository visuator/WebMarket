namespace WebMarket.Common.Messages
{
    public class GetCartProducts : IUserUid
    {
        public Guid UserId { get; set; }
    }
}
