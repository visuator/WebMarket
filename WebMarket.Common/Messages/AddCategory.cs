using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class AddCategory : IUserUid
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
