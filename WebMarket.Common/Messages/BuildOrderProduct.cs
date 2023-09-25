using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class BuildOrderProduct : StatusOrderProduct
    {
        public override OrderProductStatus SetTo { get => OrderProductStatus.Built; }
}
}
