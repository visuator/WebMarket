using AutoMapper;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Domain.Mappings
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<GetCatalogModel, GetCatalog>();
        }
    }
}
