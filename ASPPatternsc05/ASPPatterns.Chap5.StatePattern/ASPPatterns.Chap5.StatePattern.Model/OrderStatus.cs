﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StatePattern.Model
{
    /// <summary>
    /// 订单所处的状态
    /// </summary>
    public enum OrderStatus
    {
       New = 0,
       Shipped = 1,
       Canceled = 2
    }
}
