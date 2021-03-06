﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.UnitOfWork.Model
{
    /// <summary>
    /// 账户仓储
    /// 1 保存 2 添加 3 移除
    /// </summary>
    public interface IAccountRepository
    {
        void Save(Account account);
        void Add(Account account);
        void Remove(Account account);                
    }
}
