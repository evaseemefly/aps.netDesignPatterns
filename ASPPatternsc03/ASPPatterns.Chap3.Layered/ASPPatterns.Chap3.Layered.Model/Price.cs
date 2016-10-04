using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Model
{
    public class Price
    {
        /// <summary>
        /// 注意此时的实现折扣策略的接口对象为其赋予了一个默认值（空对象模式）——如此做就不会出现对象为null的错误了
        /// </summary>
        private IDiscountStrategy _discountStrategy = new NullDiscountStrategy(); 
        private decimal _rrp;
        private decimal _sellingPrice;

        public Price(decimal RRP, decimal SellingPrice)
        {
            _rrp = RRP;
            _sellingPrice = SellingPrice;
        }

        /// <summary>
        /// 将符合折扣策略的对象赋值给空的折扣策略
        /// </summary>
        /// <param name="DiscountStrategy"></param>
        public void SetDiscountStrategyTo(IDiscountStrategy DiscountStrategy)
        {
            _discountStrategy = DiscountStrategy; 
        }

        public decimal SellingPrice
        {
            get { return _discountStrategy.ApplyExtraDiscountsTo(_sellingPrice); }
        }

        public decimal RRP
        {
            get { return _rrp; }
        }

        public decimal Discount
        {
            get { 
                if (RRP > SellingPrice) 
                    return (RRP - SellingPrice); 
                else
                    return 0;}
        }

        public decimal Savings
        {
            get{
                if (RRP > SellingPrice)
                    return 1 - (SellingPrice / RRP);
                else
                    return 0;}
        }        
    }
}
