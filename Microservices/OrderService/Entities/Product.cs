namespace OrderService.Entities
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public ICollection<OrderProduct> Orders { get; set; }
    }
}
