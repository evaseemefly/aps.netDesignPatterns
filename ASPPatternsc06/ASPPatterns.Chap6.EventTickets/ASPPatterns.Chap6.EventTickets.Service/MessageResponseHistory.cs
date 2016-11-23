using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap6.EventTickets.Service
{
    /// <summary>
    /// 保存响应的字典操作类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageResponseHistory<T>
    {
        /// <summary>
        /// 保存响应的字典
        /// </summary>
        private Dictionary<string, T> _responseHistory;

        public MessageResponseHistory()
        {
            _responseHistory = new Dictionary<string, T>();
        }

        /// <summary>
        /// 判断是否是一个唯一的请求
        /// </summary>
        /// <param name="correlationId"></param>
        /// <returns></returns>
        public bool IsAUniqueRequest(string correlationId)
        {
            //在 响应 字典中判断传入的id是否唯一
            return !_responseHistory.ContainsKey(correlationId);
        }

        /// <summary>
        /// 判断指定的id是否存在，存在则修改对应的值
        /// 若不存在则创建
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="response"></param>
        public void LogResponse(string correlationId, T response)
        {
            if (_responseHistory.ContainsKey(correlationId))
                _responseHistory[correlationId] = response;
            else
                _responseHistory.Add(correlationId, response);
        }

        /// <summary>
        /// 检索之前的响应
        /// </summary>
        /// <param name="correlationId"></param>
        /// <returns></returns>
        public T RetrievePreviousResponseFor(string correlationId)
        {
            return _responseHistory[correlationId];
        }
    }
}
