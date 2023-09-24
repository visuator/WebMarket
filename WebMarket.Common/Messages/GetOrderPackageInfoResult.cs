using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class GetOrderPackageInfoResult
    {
        public Guid OrderId { get; set; }
        public List<OrderProductDto> Products { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        
        public class UserDto
        {
            public Guid Id { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
        }

        public class ProductDto
        {
            public Guid Id { get; set; }
            public string BarCode { get; set; }
        }

        public class OrderProductDto
        {
            public Guid Id { get; set; }
        }
    }
}
