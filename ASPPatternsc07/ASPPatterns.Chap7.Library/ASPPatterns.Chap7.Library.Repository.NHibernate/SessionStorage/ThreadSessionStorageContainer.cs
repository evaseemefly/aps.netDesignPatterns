using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using global::NHibernate;
using System.Collections;
using System.Threading;

namespace ASPPatterns.Chap7.Library.Repository.NHibernate.SessionStorage
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer 
    {
        private static readonly Hashtable _nhSessions = new Hashtable();

        /// <summary>
        /// 获取当前的会话
        /// </summary>
        /// <returns></returns>
        public ISession GetCurrentSession()
        {
            ISession nhSession = null;

            if (_nhSessions.Contains(GetThreadName()))
                nhSession = (ISession)_nhSessions[GetThreadName()];

            return nhSession;
        }

        /// <summary>
        /// 以当前的线程名称存储会话
        /// </summary>
        /// <param name="session"></param>
        public void Store(ISession session)
        {
            if (_nhSessions.Contains(GetThreadName()))
                _nhSessions[GetThreadName()] = session;
            else
                _nhSessions.Add(GetThreadName(), session);
        }

        /// <summary>
        /// 获取当前的线程名称
        /// </summary>
        /// <returns></returns>
        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
