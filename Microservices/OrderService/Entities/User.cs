using WebMarket.Common.Entities;

namespace OrderService.Entities
{
    public class User : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
    }
}
