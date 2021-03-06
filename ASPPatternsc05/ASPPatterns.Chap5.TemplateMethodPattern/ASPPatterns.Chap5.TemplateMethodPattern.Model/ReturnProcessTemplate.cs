﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    /// <summary>
    /// 退货模板
    /// </summary>
    public abstract class ReturnProcessTemplate
    {
        /// <summary>
        /// 生成返回事务
        /// </summary>
        /// <param name="ReturnOrder"></param>
        protected abstract void GenerateReturnTransactionFor(ReturnOrder ReturnOrder);

        /// <summary>
        /// 计算多退
        /// </summary>
        /// <param name="ReturnOrder"></param>
        protected abstract void CalculateRefundFor(ReturnOrder ReturnOrder);

        public void Process(ReturnOrder ReturnOrder)
        {
            GenerateReturnTransactionFor(ReturnOrder);
            CalculateRefundFor(ReturnOrder);
        }
    }
}
