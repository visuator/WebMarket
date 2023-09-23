namespace CartService.Entities
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
    }
}
