using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StrategyPattern.Model
{
    /// <summary>
    /// 总价折扣
    /// 按百分比打折
    /// </summary>
    public class BasketDiscountPercentageOff : IBasketDiscountStrategy 
    {
        public decimal GetTotalCostAfterApplyingDiscountTo(Basket basket)
        {
            return basket.TotalCost * 0.85m;
        }     
    }
}
