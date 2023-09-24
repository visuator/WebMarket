namespace WebMarket.Common.Messages
{
    public class GetCartProductsResult
    {
        public List<UserProductDto> Products { get; set; }

        public class UserProductDto
        {
            public Guid ProductId { get; set; }
            public ProductDto Product { get; set; }
            public Guid UserId { get; set; }
            public UserDto User { get; set; }
            public int Count { get; set; }

        }

        public class UserDto
        {
            public Guid Id { get; set; }
        }

        public class ProductDto
        {
            public Guid Id { get; set; }
            public double Price { get; set; }
        }
    }
}
