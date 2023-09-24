namespace WebMarket.Common.Messages
{
    public class AddBrand : IUserUid
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
