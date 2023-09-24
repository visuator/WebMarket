using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class ProductCreated
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
        public string BarCode { get; set; }
        public Guid BrandId { get; set; }
        public Guid UserId { get; set; }
    }
}
