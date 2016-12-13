﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASPPatterns.Chap7.Library.Repository.NHibernate.SessionStorage
{
    public static class SessionStorageFactory
    {
        public static ISessionStorageContainer _nhSessionStorageContainer;

        /// <summary>
        /// 根据是否存在Http上下文创建对应的贮藏容器
        /// </summary>
        /// <returns></returns>
        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_nhSessionStorageContainer == null)
            {
                if (HttpContext.Current == null)                                    
                    _nhSessionStorageContainer = new ThreadSessionStorageContainer();
                else
                    _nhSessionStorageContainer = new HttpSessionContainer();
            }

            return _nhSessionStorageContainer;
        }
    }
}
