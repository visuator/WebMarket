﻿using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class GetSellerOrdersResult
    {
        public List<OrderProductDto> OrderProducts { get; set; }

        public class OrderDto
        {
            public Guid Id { get; set; }
            public OrderStatus Status { get; set; }
            public List<OrderProductDto> Products { get; set; }
        }

        public class ProductDto
        {
            public Guid Id { get; set; }
            public string BarCode { get; set; }
        }

        public class OrderProductDto
        {
            public Guid OrderId { get; set; }
            public OrderDto Order { get; set; }
            public Guid ProductId { get; set; }
            public ProductDto Product { get; set; }
            public OrderProductStatus Status { get; set; }
        }
    }
}
