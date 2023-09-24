namespace WebMarket.Common.Messages
{
    public class GetOrderPackageInfoResult
    {
        public OrderDto Order { get; set; }

        public class OrderDto
        {
            public Guid Id { get; set; }
            public List<OrderProductDto> Products { get; set; }
            public Guid UserId { get; set; }
            public UserDto User { get; set; }
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
            public string BarCode { get; set; }
        }

        public class OrderProductDto
        {
            public Guid ProductId { get; set; }
            public ProductDto Product { get; set; }
        }
    }
}
