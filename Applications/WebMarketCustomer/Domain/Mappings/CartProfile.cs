using AutoMapper;

using WebMarket.Common.Messages;

using WebMarketCustomer.Models;

namespace WebMarketCustomer.Domain.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<GetCartProductsModel, GetCartProducts>();
            CreateMap<AddToCartModel, AddToCart>();
        }
    }
}
