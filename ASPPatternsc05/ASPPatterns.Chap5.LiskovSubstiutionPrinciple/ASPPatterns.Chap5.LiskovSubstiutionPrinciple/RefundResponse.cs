using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LiskovSubstitutionPrinciple
{
    /// <summary>
    /// 退款响应
    /// </summary>
    public class RefundResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
