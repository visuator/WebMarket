﻿using AutoMapper;

using ProductService.Entities;

using WebMarket.Common.Messages;

namespace ProductService.Domain.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, FindProductsResult.ProductDto>();
        }
    }
}
