using AutoMapper;

using ProductService.Entities;

using WebMarket.Common.Messages;

namespace ProductService.Domain.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddBrand, Brand>();
            CreateMap<Brand, FindProductsResult.BrandDto>();
            CreateMap<Brand, GetBrandsResult.BrandDto>();
            CreateMap<Brand, GetCatalogResult.BrandDto>();
        }
    }
}
