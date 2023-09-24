using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebMarketSeller.Models
{
    public class AddBrandModel
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
