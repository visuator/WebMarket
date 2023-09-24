using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using WebMarket.Common.Infrastructure;

namespace WebMarketSeller.Models
{
    public class AddBrandModel : IAuthenticated
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
