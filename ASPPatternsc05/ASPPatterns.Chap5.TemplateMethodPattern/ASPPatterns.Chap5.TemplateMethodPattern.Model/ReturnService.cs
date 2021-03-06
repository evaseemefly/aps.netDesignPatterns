﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.TemplateMethodPattern.Model
{
    /// <summary>
    /// 退货服务类用于根据枚举类型 通过工厂得方式创建模板类（退货模板）
    /// 并调用退货方法
    /// </summary>
    public class ReturnService
    {        
        public void Process(ReturnOrder ReturnOrder)
        {
            ReturnProcessTemplate returnProcess = ReturnProcessFactory.CreateFrom(ReturnOrder.Action);

            returnProcess.Process(ReturnOrder);                                     

            // Code to refund the back to the customer...
        }
    }
}
