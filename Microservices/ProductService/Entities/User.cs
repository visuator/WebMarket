namespace ProductService.Entities
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
