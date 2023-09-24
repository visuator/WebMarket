using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class GetCategories : IUserUid, ISupportOrdering
    {
        public bool Descending { get; set; }
        public Guid UserId { get; set; }
    }
}
