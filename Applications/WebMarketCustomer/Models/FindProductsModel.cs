namespace WebMarketCustomer.Models
{
    public class FindProductsModel
    {
        public bool Descending { get; set; }
        public Guid? CategoryId { get; set; }
        public string Pattern { get; set; }
    }
}
