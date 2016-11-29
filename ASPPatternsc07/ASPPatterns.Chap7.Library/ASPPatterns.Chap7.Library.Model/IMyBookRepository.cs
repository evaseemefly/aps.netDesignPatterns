using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Library.Model
{
    /// <summary>
    /// 自己实现的IBookRepository，将其中的公共方法抽象至IBaseRepository中，使用泛型的方式动态定义接口中的方法
    /// </summary>
    public interface IMyBookRepository:IBaseRepository<Book>
    {

    }
}
