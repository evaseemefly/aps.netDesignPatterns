using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace ASPPatterns.Chap7.Library.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 会话存储容器
    /// </summary>
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}
