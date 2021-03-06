﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StatePattern.Model.OrderStates
{
    public interface IOrderState
    {        
        /// <summary>
        /// 可以发货
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        bool CanShip(Order Order);

        /// <summary>
        /// 发货
        /// </summary>
        /// <param name="Order"></param>
        void Ship(Order Order);

        bool CanCancel(Order Order);
        void Cancel(Order order);

        OrderStatus Status { get; }
    }
}
