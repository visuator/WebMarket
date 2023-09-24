using WebMarket.Common.Entities;

namespace OrderService.Entities
{
    public class Product : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string BarCode { get; set; }
        public ICollection<OrderProduct> Orders { get; set; }
    }
}
