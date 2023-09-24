namespace WebMarket.Common.Messages
{
    public class FindProductsResult
    {
        public List<ProductDto> Products { get; set; }

        public class ProductDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Guid CategoryId { get; set; }
            public CategoryDto Category { get; set; }
            public double Price { get; set; }
            public Guid BrandId { get; set; }
            public BrandDto Brand { get; set; }
            public Guid UserId { get; set; }
            public UserDto User { get; set; }
        }

        public class CategoryDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class BrandDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class UserDto
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
        }
    }
}
