using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class AddToCart
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
