using WebMarket.Common.Entities;

namespace OrderService.Entities
{
    public class Order : BaseEntity, ISingleKeyEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderProduct> Products { get; set; }
        public Guid Id { get; set; }
    }
}
