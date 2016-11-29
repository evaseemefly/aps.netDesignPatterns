using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Infrastructure;

namespace ASPPatterns.Chap7.Library.Model
{
    public class Loan
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 借出日期
        /// </summary>
        public DateTime LoanDate { get; set; }

        /// <summary>
        /// 归还日期
        /// </summary>
        public DateTime DateForReturn { get; set; }

        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; }

        public Member Member { get; set; }

        /// <summary>
        /// 没有归还，将归还日期设置为null
        /// </summary>
        /// <returns></returns>
        public bool HasNotBeenReturned()
        {
            return ReturnDate == null;
        }

        /// <summary>
        /// 记录归还时间
        /// </summary>
        public void MarkAsReturned()
        {
            ReturnDate = DateTime.Now;            
        }
    }
}
