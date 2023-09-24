using AutoMapper;

using WebMarket.Common.Messages;

using WebMarketSeller.Models;

namespace WebMarketSeller.Domain.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductModel, AddProduct>();
        }
    }
}
