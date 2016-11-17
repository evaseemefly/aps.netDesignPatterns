using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.UnitOfWork.Infrastructure; 

namespace ASPPatterns.Chap7.UnitOfWork.Model
{
    /// <summary>
    /// 账户
    /// </summary>
    public class Account : IAggregateRoot 
    {
        /// <summary>
        /// 余额
        /// </summary>
        public decimal balance { get; set; }
    }
}
