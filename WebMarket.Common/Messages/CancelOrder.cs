﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebMarket.Common.Enums;

namespace WebMarket.Common.Messages
{
    public class CancelOrder : StatusOrder
    {
        public override OrderStatus SetTo { get => OrderStatus.Canceled; }
    }
}
