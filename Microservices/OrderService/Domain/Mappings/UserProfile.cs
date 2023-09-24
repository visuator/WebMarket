using AutoMapper;

using OrderService.Entities;

using WebMarket.Common.Messages;

namespace OrderService.Domain.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetOrderPackageInfoResult.UserDto>();
            CreateMap<UserCreated, User>();
        }
    }
}
