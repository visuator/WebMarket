using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public interface ISupportOrdering
    {
        public bool Descending { get; set; }
    }
}
