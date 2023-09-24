namespace WebMarket.Common.Messages
{
    public class GetBrandsResult
    {
        public List<BrandDto> Brands { get; set; }

        public class BrandDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
