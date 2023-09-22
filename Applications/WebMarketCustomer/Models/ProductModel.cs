namespace WebMarketCustomer.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public string BrandName { get; set; }
        public Guid BrandId { get; set; }
        public double Price { get; set; }
        public int OrdersCount { get; set; }
    }
}
