using System.Text.Json.Serialization;

namespace WebMarketCustomer.Models
{
    public class GetCartProductsModel 
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
