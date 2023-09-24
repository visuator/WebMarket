using System.ComponentModel.DataAnnotations;

namespace WebMarketCustomer.Models
{
    public class CreateUserModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Address { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
