using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LiskovSubstitutionPrinciple
{
    /// <summary>
    /// 退款请求
    /// </summary>
    public class RefundRequest
    {
        public PaymentType Payment { get; set; }
        public string PaymentTransactionId { get; set; }
        public decimal RefundAmount { get; set; }
    }
}
