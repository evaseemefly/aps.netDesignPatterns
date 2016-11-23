using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.UnitOfWork.Infrastructure
{
    /// <summary>
    /// 工作单元接口
    /// 寄存器 1 修改 2 新增 3 删除 4 接受
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 寄存器修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// 寄存器新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// 寄存器删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);
        /// <summary>
        /// 接受
        /// </summary>
        void Commit();
    }
}
