using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap3.Layered.Model;   

namespace ASPPatterns.Chap3.Layered.Service
{
    /// <summary>
    /// 客户端与服务层交互，使用Request/Response模式
    /// 其中Request由客户端提供，将携带所有必要的参数，
    /// 此处包含CustomerType 枚举类型
    /// </summary>
    public class ProductListRequest
    {
        public CustomerType CustomerType { get; set; }
    }
}
