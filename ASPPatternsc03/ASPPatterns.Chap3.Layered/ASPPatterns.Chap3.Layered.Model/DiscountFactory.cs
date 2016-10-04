using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Model
{
    public static class DiscountFactory
    {
        /// <summary>
        /// 根据传入的值来判断是创建折扣策略还是不使用折扣
        /// </summary>
        /// <param name="customerType"></param>
        /// <returns></returns>
        public static IDiscountStrategy GetDiscountStrategyFor(CustomerType customerType)
        {
            switch (customerType)
            {
                case CustomerType.Trade:
                    return new TradeDiscountStrategy(); 
                default:
                    return new NullDiscountStrategy(); 
            }
        }
    }
}
