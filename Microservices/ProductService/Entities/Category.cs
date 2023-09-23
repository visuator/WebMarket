using WebMarket.Common.Entities;

namespace ProductService.Entities
{
    public class Category : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
