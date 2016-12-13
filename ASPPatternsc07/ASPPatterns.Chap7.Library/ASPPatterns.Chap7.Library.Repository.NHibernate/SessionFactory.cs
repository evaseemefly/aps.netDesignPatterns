using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using ASPPatterns.Chap7.Library.Repository.NHibernate.SessionStorage;

namespace ASPPatterns.Chap7.Library.Repository.NHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory _SessionFactory;        

        /// <summary>
        /// 只被调用一次
        /// 根据NH的配置文件对NB进行初始化
        /// </summary>
        private static void Init()
        {
            Configuration config = new Configuration();
            config.AddAssembly("ASPPatterns.Chap7.Library.Repository.NHibernate");

            log4net.Config.XmlConfigurator.Configure();
            
            config.Configure();

            _SessionFactory = config.BuildSessionFactory();
        }

        /// <summary>
        /// 执行初始化操作，并创建SessionFactory
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory GetSessionFactory()
        {
            if (_SessionFactory == null)
                Init();

            return _SessionFactory;
        }

        private static ISession GetNewSession()
        {
            //取到单例的SessionFactory
            return GetSessionFactory().OpenSession();
        }

        /// <summary>
        /// 获取当前的会话
        /// </summary>
        /// <returns></returns>
        public static ISession GetCurrentSession()
        {
            //获取贮藏容器
            ISessionStorageContainer _sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            //每个实现的贮藏容器获得当前的
            ISession currentSession = _sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                //获取当前贮藏中的会话（需打开OpenSession）
                currentSession = GetNewSession();
                //贮藏容器执行存储当前会话的操作
                _sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }
    }
}
