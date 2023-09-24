﻿using AutoMapper;

using ProductService.Entities;
using WebMarket.Common.Messages;

namespace ProductService.Domain.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, FindProductsResult.CategoryDto>();
        }
    }
}