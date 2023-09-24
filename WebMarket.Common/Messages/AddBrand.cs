using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class AddBrand : IUserUid
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
