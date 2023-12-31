﻿using AutoMapper;

using OrderService.Entities;

using WebMarket.Common.Messages;

namespace OrderService.Domain.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetOrderPackageInfoResult.ProductDto>();
            CreateMap<Product, GetUserOrdersResult.ProductDto>();
            CreateMap<Product, GetSellerOrdersResult.ProductDto>();
            CreateMap<ProductCreated, Product>();
            CreateMap<Product, OrderCreated.ProductDto>();
        }
    }
}
