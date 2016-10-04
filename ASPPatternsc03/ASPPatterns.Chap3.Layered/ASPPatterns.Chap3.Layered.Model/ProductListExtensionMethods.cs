using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Model
{
    public static class ProductListExtensionMethods
    {
        /// <summary>
        /// 为所有传入的 产品 对象 赋予统一的折扣策略（传入的discountStrategy）
        /// </summary>
        /// <param name="products"></param>
        /// <param name="discountStrategy"></param>
        public static void Apply(this IList<Product> products, IDiscountStrategy discountStrategy)
        {
            //为所有传入的 产品 对象 赋予统一的折扣策略（传入的discountStrategy）
            foreach (Product p in products)
            {
                p.Price.SetDiscountStrategyTo(discountStrategy);
            }
        }
    }
}
