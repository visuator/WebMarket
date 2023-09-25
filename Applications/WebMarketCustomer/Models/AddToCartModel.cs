using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using WebMarket.Common.Infrastructure;

namespace WebMarketCustomer.Models
{
    public class AddToCartModel : IAuthenticated
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}
