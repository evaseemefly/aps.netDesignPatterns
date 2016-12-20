using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace ASPPatterns.Chap7.Library.Repository.EF.DataContextStorage
{
    /// <summary>
    /// 
    /// </summary>
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer 
    {    
        /// <summary>
        /// 存储图书馆数据上下文对象的key value集合
        /// </summary>
        private static readonly Hashtable _libraryDataContexts = new Hashtable();

        /// <summary>
        /// 获得数据上下文对象
        /// </summary>
        /// <returns></returns>
        public LibraryDataContext GetDataContext()
        {
            LibraryDataContext libraryDataContext = null;

            //判断图书馆hash表中是否包含key为 当前线程名 的value
            if (_libraryDataContexts.Contains(GetThreadName()))
                //将当前线程名作为key 从 hash表中取出该key对应的value
                libraryDataContext = (LibraryDataContext)_libraryDataContexts[GetThreadName()];           

            return libraryDataContext;
        }

        /// <summary>
        /// 将传入的数据上下文对象存储到hash表中
        /// </summary>
        /// <param name="libraryDataContext"></param>
        public void Store(LibraryDataContext libraryDataContext)
        {
            //判断当前上下文对象中是否包含指定的key（当前线程名）对应的数据上下文对象
            if (_libraryDataContexts.Contains(GetThreadName()))
                //若有则将该key存储的value改为传入的数据上下文对象
                _libraryDataContexts[GetThreadName()] = libraryDataContext;
            else
                //若不存在则添加一个至hashtable中
                _libraryDataContexts.Add(GetThreadName(), libraryDataContext);           
        }

        /// <summary>
        /// 获得当前线程的名称
        /// </summary>
        /// <returns></returns>
        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }     
    }
}
