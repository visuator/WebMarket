using AutoMapper;

using UserService.Entities;

using WebMarket.Common.Messages;

namespace UserService.Domain.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUser, User>()
                .ForMember(x => x.PasswordHash, opt => opt.Ignore())
                .ForMember(x => x.PasswordSalt, opt => opt.Ignore());
            CreateMap<User, UserCreated>();
        }
    }
}
