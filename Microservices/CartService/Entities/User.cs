using WebMarket.Common.Entities;

namespace CartService.Entities
{
    public class User : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
    }
}
