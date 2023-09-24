using WebMarket.Common.Entities;

namespace OrderService.Entities
{
    public class User : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
