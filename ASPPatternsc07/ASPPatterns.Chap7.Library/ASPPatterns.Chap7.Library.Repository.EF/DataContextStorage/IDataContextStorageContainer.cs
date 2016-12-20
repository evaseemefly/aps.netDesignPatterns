using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Library.Repository.EF.DataContextStorage
{
    /// <summary>
    /// 存储容器接口
    /// </summary>
    public interface IDataContextStorageContainer
    {
        /// <summary>
        /// 获得数据上下文对象
        /// </summary>
        /// <returns></returns>
        LibraryDataContext GetDataContext();
        /// <summary>
        /// 持久化
        /// </summary>
        /// <param name="libraryDataContext"></param>
        void Store(LibraryDataContext libraryDataContext);
    }
}
