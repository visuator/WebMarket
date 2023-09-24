using AutoMapper;

using WebMarket.Common.Messages;
using WebMarketSeller.Models;

namespace WebMarketSeller.Domain.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCategoryModel, AddCategory>();
            CreateMap<GetCategoriesModel, GetCategories>();
        }
    }
}
