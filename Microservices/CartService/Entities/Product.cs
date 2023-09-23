using WebMarket.Common.Entities;

namespace CartService.Entities
{
    public class Product : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
    }
}
