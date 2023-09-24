using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace UserService.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public TimeSpan Expiration { get; set; }

        public SecurityKey SecurityKey
        {
            get => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }
    }
}
