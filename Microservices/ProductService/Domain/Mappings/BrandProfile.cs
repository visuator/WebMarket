using AutoMapper;

using ProductService.Entities;
using WebMarket.Common.Messages;

namespace ProductService.Domain.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, FindProductsResult.BrandDto>();
            CreateMap<Brand, GetBrandsResult.BrandDto>();
        }
    }
}
