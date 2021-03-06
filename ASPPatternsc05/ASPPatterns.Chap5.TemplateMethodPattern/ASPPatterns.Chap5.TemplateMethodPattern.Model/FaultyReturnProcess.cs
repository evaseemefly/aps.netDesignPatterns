﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    public class FaultyReturnProcess : ReturnProcessTemplate
    {
        protected override void GenerateReturnTransactionFor(ReturnOrder ReturnOrder)
        {
            // Code to send generate order that sends faulty item back to
            // manufacturer...
        }

        /// <summary>
        /// 计算退还给用户的金额
        /// 由于是 缺陷退货 故退还给用户 商品总价+运费
        /// </summary>
        /// <param name="ReturnOrder"></param>
        protected override void CalculateRefundFor(ReturnOrder ReturnOrder)
        {
            ReturnOrder.AmountToRefund = ReturnOrder.PricePaid + ReturnOrder.PostageCost;
        }
    }
}
