using System.Text.Json.Serialization;

using WebMarket.Common.Infrastructure;

namespace WebMarketCustomer.Models
{
    public class GetCartProductsModel : IAuthenticated
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
