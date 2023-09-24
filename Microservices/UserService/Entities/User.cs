using WebMarket.Common.Entities;

namespace UserService.Entities
{
    public class User : BaseEntity, ISingleKeyEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string? Address { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
