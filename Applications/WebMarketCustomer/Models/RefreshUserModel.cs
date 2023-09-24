using System.ComponentModel.DataAnnotations;

namespace WebMarketCustomer.Models
{
    public class RefreshUserModel
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
