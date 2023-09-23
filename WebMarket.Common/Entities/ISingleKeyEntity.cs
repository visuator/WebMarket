using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Entities
{
    public interface ISingleKeyEntity
    {
        Guid Id { get; set; }
    }
}
