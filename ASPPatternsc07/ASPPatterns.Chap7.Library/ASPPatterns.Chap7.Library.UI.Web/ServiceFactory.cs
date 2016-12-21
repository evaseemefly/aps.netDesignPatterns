using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPPatterns.Chap7.Library.Services;
using ASPPatterns.Chap7.Library.Model;
using ASPPatterns.Chap7.Library.Infrastructure; 
using ASPPatterns.Chap7.Library;
using ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork;
using System.Configuration;

namespace ASPPatterns.Chap7.Library.UI.Web
{
    /// <summary>
    /// For a better solution take a look at chapter 8 which uses an IoC Container to inject the concrete implementations
    /// </summary>
    public static class ServiceFactory
    {        
        public static LibraryService CreateLibraryService()
        {
            IUnitOfWork uow;
            IBookRepository bookRespository;
            IBookTitleRepository bookTitleRepository;
            IMemberRepository memberRespository;

            //读取配置文件中的持久性策略的配置节
            string persistenceStrategy = ConfigurationManager.AppSettings["PersistenceStrategy"];

            //根据读取的配置节创建不同的持久化对象
            //EF
            if (persistenceStrategy == "EF")
            {
                uow = new Repository.EF.EFUnitOfWork();
                bookRespository = new Repository.EF.Repositories.BookRepository(uow);
                bookTitleRepository = new Repository.EF.Repositories.BookTitleRepository(uow);
                memberRespository = new Repository.EF.Repositories.MemberRepository(uow);
            }
            //NHibernate
            else
            {
                uow = new Repository.NHibernate.NHUnitOfWork();
                bookRespository = new Repository.NHibernate.Repositories.BookRepository(uow);
                bookTitleRepository = new Repository.NHibernate.Repositories.BookTitleRepository(uow);
                memberRespository = new Repository.NHibernate.Repositories.MemberRepository(uow);
            }

            return new LibraryService(bookTitleRepository, bookRespository, memberRespository, uow);
        }
    }
}