using System.ComponentModel.DataAnnotations;

namespace WebMarketCustomer.Models
{
    public class LoginUserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
