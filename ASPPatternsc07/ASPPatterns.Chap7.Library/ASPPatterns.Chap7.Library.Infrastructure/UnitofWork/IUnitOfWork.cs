using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Library.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 寄存器修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// 寄存器创建
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// 寄存器移除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// 指派——委托
        /// </summary>
        void Commit();
    }

}
