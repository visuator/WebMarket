namespace WebMarket.Common.Messages
{
    public class CreateOrder : IUserUid
    {
        public Guid UserId { get; set; }
        public List<Guid> CartItemsIds { get; set; }
    }
}
