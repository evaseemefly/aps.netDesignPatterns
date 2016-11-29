using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Library.Model
{
    public static class LoanFactory
    {
        /// <summary>
        /// 创建借书的借条（何时应该归还，借阅时间等）
        /// </summary>
        /// <param name="book"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static Loan CreateLoanFrom(Book book, Member member)
        {
            Loan loan = new Loan();            
            loan.Book = book;
            loan.Member = member;
            loan.LoanDate = DateTime.Now;
            loan.DateForReturn = DateTime.Now.AddDays(7);            
            return loan;
        }
    }
}
