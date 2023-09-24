namespace WebMarket.Common.Messages
{
    public class GetCategoriesResult
    {
        public List<CategoryDto> Categories { get; set; }

        public class CategoryDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
