using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Model
{
    /// <summary>
    /// 折扣策略
    /// </summary>
    public interface IDiscountStrategy
    {
        /// <summary>
        /// 申请额外的折扣
        /// </summary>
        /// <param name="OriginalSalePrice"></param>
        /// <returns></returns>
        decimal ApplyExtraDiscountsTo(decimal OriginalSalePrice);
    }
}
