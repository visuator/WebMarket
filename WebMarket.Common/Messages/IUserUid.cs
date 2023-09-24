using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public interface IUserUid
    {
        public Guid UserId { get; set; }
    }
}
