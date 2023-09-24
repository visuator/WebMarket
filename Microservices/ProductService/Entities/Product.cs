using WebMarket.Common.Entities;

namespace ProductService.Entities
{
    public class Product : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
