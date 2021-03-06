﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    /// <summary>
    /// 定义退货的种类是何种类型
    /// </summary>
    public enum ReturnAction
    {
        /// <summary>
        /// 有缺陷退货
        /// </summary>
        FaultyReturn = 0,
        /// <summary>
        /// 无条件退货
        /// </summary>
        NoQuibblesReturn = 1
    }
}
