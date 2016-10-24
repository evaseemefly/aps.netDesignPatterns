using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.StrategyPattern.Model
{
    public class Basket
    {
        private IBasketDiscountStrategy _basketDiscount;

        /// <summary>
        /// 通过构造函数实现创建具体的打折策略对象
        /// </summary>
        /// <param name="discountType"></param>
        public Basket(DiscountType discountType)
        {
            //根据枚举类型使用工厂方法创建指定的打折策略（都实现了IBasketDiscountStrategy接口）
            //实现了该接口的具体实现类中都实现了GetTotalCostAfterApplyingDiscountTo方法实现打折
            _basketDiscount = BasketDiscountFactory.GetDiscount(discountType);
        }

        public decimal TotalCost { get; set; }

        /// <summary>
        /// 调用IBasketDiscountStrategy接口中的GetTotalCostAfterApplyingDiscountTo 方法 实现打折
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalCostAfterDiscount()
        {
            return _basketDiscount.GetTotalCostAfterApplyingDiscountTo(this); 
        }
    }
}
