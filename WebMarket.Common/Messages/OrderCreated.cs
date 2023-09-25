using MassTransit.Transports;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class OrderCreated
    {
        public OrderDto Order { get; set; }
        public class OrderDto
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public UserDto User { get; set; }
            public OrderStatus Status { get; set; }
            public ICollection<OrderProductDto> Products { get; set; }
        }

        public class UserDto
        {
            public Guid Id { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
        }

        public class ProductDto
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public UserDto User { get; set; }
            public string BarCode { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public ICollection<OrderProductDto> Orders { get; set; }
        }

        public class OrderProductDto
        {
            public Guid OrderId { get; set; }
            public OrderDto Order { get; set; }
            public Guid ProductId { get; set; }
            public ProductDto Product { get; set; }
        }
    }
}
