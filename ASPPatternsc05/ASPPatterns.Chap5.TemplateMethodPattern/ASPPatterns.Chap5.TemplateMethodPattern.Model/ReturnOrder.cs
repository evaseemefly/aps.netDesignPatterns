using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    /// <summary>
    /// 退货订单
    /// </summary>
    public class ReturnOrder
    {
        /// <summary>
        /// 退货订单类型
        /// </summary>
        public ReturnAction Action { get; set; }

        /// <summary>
        ///  
        /// </summary>
        public string PaymentTransactionId { get; set; }

        /// <summary>
        /// 订单总价
        /// </summary>
        public decimal PricePaid { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public decimal PostageCost { get; set; }

        /// <summary>
        /// 退还给客户的总金额
        /// </summary>
        public decimal AmountToRefund { get; set; }
        /// <summary>
        /// 退货商品id
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long QtyBeingReturned { get; set; }
    }
}
