using System.Text.Json.Serialization;

using WebMarket.Common.Infrastructure;

namespace WebMarketSeller.Models
{
    public class GetCatalogModel : IAuthenticated
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
