using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap8.IoC.Model.Despatch
{
    /// <summary>
    /// 派送服务
    /// </summary>
    public class DespatchService : IDespatchService 
    {
        private ICourier _courier;

        public DespatchService(ICourier courier)
        {
            _courier = courier;
        }

        public override string ToString()
        {
            return _courier.ToString();
        }
    }
}
