using WebMarket.Common.Entities;

namespace UserService.Entities
{
    public class Session : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
