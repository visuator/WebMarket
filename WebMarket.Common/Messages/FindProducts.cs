namespace WebMarket.Common.Messages
{
    public class FindProducts : ISupportOrdering
    {
        public bool Descending { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Pattern { get; set; }
    }
}
