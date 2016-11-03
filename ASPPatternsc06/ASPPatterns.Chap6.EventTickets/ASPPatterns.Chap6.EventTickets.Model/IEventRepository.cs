using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Model
{
    /// <summary>
    /// 事件仓储接口
    /// </summary>
    public interface IEventRepository
    {
        /// <summary>
        /// 获取指定事件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Event FindBy(Guid id);
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="eventEntity"></param>
        void Save(Event eventEntity);       
    }
}
