using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class FindProducts
    {
        public bool Descending { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Pattern { get; set; }
    }
}
