using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LiskovSubstitutionPrinciple
{
    // Stub class to act as a PayPal web service
    public class MockPayPalWebService
    {
        /// <summary>
        /// 获得令牌
        /// </summary>
        /// <param name="AccountName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public string ObtainToken(string AccountName, string Password)
        {
            return "";
        }

        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="transactionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string MakeRefund(decimal amount, string transactionId, string token)
        {
            return "Auth:0999";
        }
    }
}
