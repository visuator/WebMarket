using WebMarket.Common.Entities;

namespace CartService.Entities
{
    public class UserProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Count { get; set; }
    }
}
