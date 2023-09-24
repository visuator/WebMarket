using System.ComponentModel.DataAnnotations;

namespace WebMarketCustomer.Models
{
    public class FindProductsModel
    {
        [Required]
        public bool Descending { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Pattern { get; set; }
    }
}
