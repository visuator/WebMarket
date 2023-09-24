using AutoMapper;

using CartService.Entities;

using WebMarket.Common.Messages;

namespace CartService.Domain.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreated, User>();
        }
    }
}
