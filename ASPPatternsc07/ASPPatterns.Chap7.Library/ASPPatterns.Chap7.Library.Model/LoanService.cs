using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Infrastructure;
using ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork;

namespace ASPPatterns.Chap7.Library.Model
{
    public class LoanService
    {        
        private IMemberRepository _memberRepository;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// 使用构造函数的方式实现依赖注入
        /// </summary>
        /// <param name="bookRepository"></param>
        /// <param name="memberRepository"></param>
        /// <param name="unitOfWork"></param>
        public LoanService(IBookRepository bookRepository,
                           IMemberRepository memberRepository,                                    
                           IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;            
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// 协调book 的借出
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public Loan Loan(Guid memberId, Guid bookId)
        {
            Loan loan = default(Loan);
            Book book = _bookRepository.FindBy(bookId);
            Member member = _memberRepository.FindBy(memberId);

            if (member.CanLoan(book))
            {
                member.Loan(book);
                book.OnLoanTo = member;
                _memberRepository.Save(member);                
                _bookRepository.Save(book); 
                _unitOfWork.Commit();
            }            
             
            return loan;
        }

        /// <summary>
        /// 协调book的归还
        /// </summary>
        /// <param name="bookId"></param>
        public void Return(Guid bookId)
        {
            //找到指定图书
            Book book = _bookRepository.FindBy(bookId);
            //获取该图书借给谁了
            Member member = book.OnLoanTo;
            //该借书人 进行 归还操作
            member.Return(book);

            _memberRepository.Save(member);
            _bookRepository.Save(book);
            _unitOfWork.Commit();
        }
    }
}
