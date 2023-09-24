namespace WebMarketCustomer.Models
{
    public class CreateOrderModel
    {
        public Guid UserId { get; set; }
        public List<Guid> CartItemsIds { get; set; }
    }
}
