using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap4.DomainModel.Model
{
    public class Transaction
    {
        public Transaction(decimal deposit, decimal withdrawal, string reference, DateTime date)
        {            
            this.Deposit = deposit;
            this.Withdrawal = withdrawal;
            this.Reference = reference;
            this.Date = date;
        }
              
        /// <summary>
        /// 存钱——
        /// </summary>
        public decimal Deposit
        { get; internal set; }

        /// <summary>
        /// 取钱——
        /// </summary>
        public decimal Withdrawal
        { get; internal set; }

        /// <summary>
        /// 参考
        /// </summary>
        public string Reference
        { get; internal set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date
        { get; internal set; }
    }
}
