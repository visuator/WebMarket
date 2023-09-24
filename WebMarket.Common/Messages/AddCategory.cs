namespace WebMarket.Common.Messages
{
    public class AddCategory : IUserUid
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
