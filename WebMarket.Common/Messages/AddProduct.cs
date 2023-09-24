namespace WebMarket.Common.Messages
{
    public class AddProduct : IUserUid
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
        public string BarCode { get; set; }
        public Guid BrandId { get; set; }
    }
}
