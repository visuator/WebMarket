using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class GetOrdersResult
    {
        public List<OrderDto> Orders { get; set; }

        public class OrderDto
        {
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
        }
    }
}
