using WebMarket.Common.Entities;

namespace OrderService.Entities
{
    public class Product : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public ICollection<OrderProduct> Orders { get; set; }
    }
}
