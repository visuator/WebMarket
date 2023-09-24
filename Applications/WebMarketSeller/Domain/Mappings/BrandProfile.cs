using AutoMapper;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Domain.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddBrandModel, AddBrand>();
            CreateMap<GetBrandsModel, GetBrands>();
        }
    }
}
