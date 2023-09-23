using AutoMapper;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Domain.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserModel, CreateUser>();
        }
    }
}
