using WebMarket.Common.Entities;

namespace ProductService.Entities
{
    public class User : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
