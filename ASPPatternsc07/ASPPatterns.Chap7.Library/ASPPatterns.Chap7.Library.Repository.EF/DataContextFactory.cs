using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ASPPatterns.Chap7.Library.Repository.EF.DataContextStorage;

namespace ASPPatterns.Chap7.Library.Repository.EF
{
    public class DataContextFactory
    {      
        public static LibraryDataContext GetDataContext()
        {
            //由工厂方法获取贮藏存储对象
            IDataContextStorageContainer _dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();

            //由于贮藏存储对象实现了指定接口，即实现了GetDataContext方法，调用该方法获取上下文对象
            LibraryDataContext libraryDataContext = _dataContextStorageContainer.GetDataContext();
            if (libraryDataContext == null)
            {
                libraryDataContext = new LibraryDataContext();
                _dataContextStorageContainer.Store(libraryDataContext);
            }

            return libraryDataContext;            
        }       
    }
}
