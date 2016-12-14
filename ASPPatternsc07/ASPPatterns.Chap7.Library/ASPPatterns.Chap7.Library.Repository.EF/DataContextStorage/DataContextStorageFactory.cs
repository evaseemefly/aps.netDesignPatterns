using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASPPatterns.Chap7.Library.Repository.EF.DataContextStorage
{
    /// <summary>
    /// 数据上下文贮藏工厂，由外侧的数据上下文工厂调用
    /// </summary>
    public class DataContextStorageFactory
    {
        public static IDataContextStorageContainer _dataContectStorageContainer;

        public static IDataContextStorageContainer CreateStorageContainer()
        {
            if (_dataContectStorageContainer == null)
            {
                if (HttpContext.Current == null)                                    
                    _dataContectStorageContainer = new ThreadDataContextStorageContainer();
                else
                    _dataContectStorageContainer = new HttpDataContextStorageContainer();
            }

            return _dataContectStorageContainer;
        }
    }
}
