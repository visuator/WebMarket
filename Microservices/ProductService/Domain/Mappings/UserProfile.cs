using AutoMapper;

using ProductService.Entities;

using WebMarket.Common.Messages;

namespace ProductService.Domain.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, FindProductsResult.UserDto>();
        }
    }
}
