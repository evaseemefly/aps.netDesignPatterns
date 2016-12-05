using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Services.Messages;
using ASPPatterns.Chap7.Library.Services.Mappers;
using ASPPatterns.Chap7.Library.Services.Views;
using ASPPatterns.Chap7.Library.Model;
using ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork;

namespace ASPPatterns.Chap7.Library.Services
{
    /// <summary>
    /// 图书馆服务
    /// </summary>
    public class LibraryService
    {
        private IUnitOfWork _uow;        
        private IBookRepository _bookRepository;
        private IBookTitleRepository _bookTitleRepository;
        private IMemberRepository _memberRepository;
        /// <summary>
        /// 借书服务类
        /// </summary>
        private LoanService _loanService; 

        public LibraryService(IBookTitleRepository bookTitleRepository,
                             IBookRepository bookRepository, 
                             IMemberRepository memberRepository,
                             IUnitOfWork unitOfWork)
        {            
            _uow = unitOfWork;
            _memberRepository = memberRepository; 
            _bookTitleRepository = bookTitleRepository;
            _bookRepository = bookRepository;
            _loanService = new LoanService(_bookRepository, _memberRepository, _uow);
        }

        public AddBookResponse AddBook(AddBookRequest request)
        {
            AddBookResponse response = new AddBookResponse();

            BookTitle bookTitle = _bookTitleRepository.FindBy( request.ISBN); 
            Book book = new Book();
            book.Title = bookTitle;
            book.Id = Guid.NewGuid();
            _bookRepository.Add(book);
            _uow.Commit();

            response.Success = true;

            return response;
        }

        public AddBookTitleResponse AddBookTitle(AddBookTitleRequest request)
        {
            AddBookTitleResponse response = new AddBookTitleResponse();

            BookTitle bookTitle = new BookTitle();
            bookTitle.ISBN = request.ISBN;
            bookTitle.Title = request.Title;

            _bookTitleRepository.Add(bookTitle);
            _uow.Commit();

            response.Success = true;

            return response;
        }


        public FindBooksResponse FindBooks(FindBooksRequest request)
        {
            FindBooksResponse response = new FindBooksResponse();

            IEnumerable<Book> books = _bookRepository.FindAll();
            IEnumerable<BookView> bookViews = books.ConvertToBookViews();

            response.Books = bookViews;

            return response;
        }

        public FindBookTitlesResponse FindBookTitles(FindBookTitlesRequest request)
        {
            FindBookTitlesResponse response = new FindBookTitlesResponse();

            IList<BookTitleView> bookTitles = new List<BookTitleView>();

            if (request.All)
            {
                bookTitles = _bookTitleRepository.FindAll().ConvertToBookTitleViews();
            }
            else
            {
                BookTitle bookTitle = _bookTitleRepository.FindBy(request.ISBN);
                bookTitles.Add(bookTitle.ConvertToBookTitleView());
            }

            response.BookTitles = bookTitles;
            response.Success = true; 

            return response;
        }

        /// <summary>
        /// 借书
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LoanBookResponse LoanBook(LoanBookRequest request)
        {
            //借书的响应
            LoanBookResponse response = new LoanBookResponse();

            //调用借书服务类借书
            Loan loan = _loanService.Loan(new Guid(request.MemberId), new Guid(request.CopyId));

            if (loan != null)
            {
                response.loan = loan.ConvertToLoanView();
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        /// <summary>
        /// 还书
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ReturnBookResponse ReturnBook(ReturnBookRequest request)
        {
            //还书的响应
            ReturnBookResponse response = new ReturnBookResponse();

            _loanService.Return(new Guid(request.CopyId));

            return response;
        }

        public AddMemberResponse AddMember(AddMemberRequest request)
        {
            AddMemberResponse response = new AddMemberResponse();

            Member member = new Member();
            member.FirstName = request.FirstName;
            member.LastName = request.LastName;
            member.Id = Guid.NewGuid();

            _memberRepository.Add(member);
            _uow.Commit();

            return response;
        }

        public FindMembersResponse FindMembers(FindMemberRequest request)
        {
            FindMembersResponse response = new FindMembersResponse();
            IList<MemberView> members = new List<MemberView>();

            if (request.All)
            {
                members = _memberRepository.FindAll().ConvertToMemberViews();
            }
            else
            {
                Member member = _memberRepository.FindBy(new Guid(request.MemberId));
                members.Add(member.ConvertToMemberView());
            }

            response.MembersFound = members;
            response.Success = true;

            return response;
        }
    }
}
