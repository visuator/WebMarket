using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using WebMarket.Common.Infrastructure;

namespace WebMarketSeller.Models
{
    public class GetCategoriesModel : IAuthenticated
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        public bool Descending { get; set; }
    }
}
