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
        /// <summary>
        /// 定义一个静态的契约（接口）由web与非web的实现类实现
        /// </summary>
        public static IDataContextStorageContainer _dataContectStorageContainer;

        /// <summary>
        /// 创建贮藏容器（根据需要）返回一个 数据容器（其中实现 获得 与 存储 数据上下文对象的方法）
        /// </summary>
        /// <returns></returns>
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
