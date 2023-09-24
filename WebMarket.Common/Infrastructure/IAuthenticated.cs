using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Infrastructure
{
    public interface IAuthenticated
    {
        Guid UserId { get; set; }
    }
}
