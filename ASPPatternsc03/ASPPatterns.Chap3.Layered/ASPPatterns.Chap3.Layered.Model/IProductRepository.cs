using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Model
{
    /// <summary>
    /// 产品仓库接口
    /// </summary>
    public interface IProductRepository
    {
        IList<Product> FindAll();
    }
}
