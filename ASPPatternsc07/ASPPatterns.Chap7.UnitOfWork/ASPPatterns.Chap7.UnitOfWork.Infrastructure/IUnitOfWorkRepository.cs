using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.UnitOfWork.Infrastructure
{
    /// <summary>
    /// 工作单元仓储接口
    /// 与持久化有关的操作
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        /// <summary>
        /// 持久化创建
        /// </summary>
        /// <param name="entity"></param>
        void PersistCreationOf(IAggregateRoot entity);

        /// <summary>
        /// 持久化更新
        /// </summary>
        /// <param name="entity"></param>
        void PersistUpdateOf(IAggregateRoot entity);

        /// <summary>
        /// 持久化删除
        /// </summary>
        /// <param name="entity"></param>
        void PersistDeletionOf(IAggregateRoot entity);
    }
}
