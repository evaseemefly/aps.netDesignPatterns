using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StrategyPattern.Model
{
    /// <summary>
    /// 折扣策略
    /// </summary>
    public interface IBasketDiscountStrategy
    {
        /// <summary>
        /// 折扣后总成本
        /// </summary>
        /// <param name="basket">购物车</param>
        /// <returns></returns>
        decimal GetTotalCostAfterApplyingDiscountTo(Basket basket);
    }
}
