using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebMarketSeller.Models
{
    public class GetCategoriesModel
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        public bool Descending { get; set; }
    }
}
