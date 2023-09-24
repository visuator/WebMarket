using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using WebMarket.Common.Infrastructure;

namespace WebMarketCustomer.Models
{
    public class CreateOrderModel : IAuthenticated
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        public List<Guid> CartItemsIds { get; set; }
    }
}
