using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LiskovSubstitutionPrinciple
{
    public class MockWorldPayWebService
    {
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="transactionId"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public string MakeRefund(decimal amount, string transactionId, string username, string password, string ProductId)
        {
            return "A_Success-09901";
        }
    }
}
