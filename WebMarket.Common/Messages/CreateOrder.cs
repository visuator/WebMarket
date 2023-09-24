using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class CreateOrder : IUserUid
    {
        public Guid UserId { get; set; }
        public List<Guid> CartItemsIds { get; set; }
    }
}
