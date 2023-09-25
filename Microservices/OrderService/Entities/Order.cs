using WebMarket.Common.Entities;
using WebMarket.Common.Enums;

namespace OrderService.Entities
{
    public class Order : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderProduct> Products { get; set; }
    }
}
