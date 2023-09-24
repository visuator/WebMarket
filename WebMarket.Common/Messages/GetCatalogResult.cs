namespace WebMarket.Common.Messages
{
    public class GetCatalogResult
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
            public string BarCode { get; set; }
            public Guid BrandId { get; set; }
            public BrandDto Brand { get; set; }
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
    }
}
