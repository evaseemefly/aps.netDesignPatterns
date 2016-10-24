using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StrategyPattern.Model
{
    public enum DiscountType
    {
        /// <summary>
        /// 无折扣
        /// </summary>
        NoDiscount = 0,
        /// <summary>
        /// 满足多少钱后打折
        /// </summary>
        MoneyOff = 1,
        /// <summary>
        /// 按比例打折
        /// </summary>
        PercentageOff = 2
    }
}
