﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Common.Messages
{
    public class GetOrderPackageInfo : IOrderUid
    {
        public Guid OrderId { get; set; }
    }
}
