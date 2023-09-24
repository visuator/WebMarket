using WebMarket.Common.Entities;

namespace ProductService.Entities
{
    public class Brand : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
    }
}
