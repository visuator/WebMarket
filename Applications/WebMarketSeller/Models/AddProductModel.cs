using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using WebMarket.Common.Infrastructure;

namespace WebMarketSeller.Models
{
    public class AddProductModel : IAuthenticated
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string BarCode { get; set; }
        [Required]
        public Guid BrandId { get; set; }
    }
}
