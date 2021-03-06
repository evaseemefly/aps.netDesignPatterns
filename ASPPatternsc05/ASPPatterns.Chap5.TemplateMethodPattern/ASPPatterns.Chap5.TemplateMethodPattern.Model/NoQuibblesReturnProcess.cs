﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class NoQuibblesReturnProcess : ReturnProcessTemplate
    {
        protected override void GenerateReturnTransactionFor(ReturnOrder ReturnOrder)
        {
            // Code to put items back into stock...
        }

        /// <summary>
        /// 无理由退货 为退单中的 退还给客户的总金额为订单总价
        /// </summary>
        /// <param name="ReturnOrder"></param>
        protected override void CalculateRefundFor(ReturnOrder ReturnOrder)
        {            
            ReturnOrder.AmountToRefund = ReturnOrder.PricePaid; 
        }
    }
}
