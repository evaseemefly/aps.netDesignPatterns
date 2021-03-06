﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap8.MVP.Model;

namespace ASPPatterns.Chap8.MVP.Presentation
{
    public interface IHomeView
    {
        /// <summary>
        /// 高销量的产品
        /// </summary>
        IEnumerable<Product> TopSellingProduct { set; } 

        /// <summary>
        /// 种类集合
        /// </summary>
        IEnumerable<Category> CategoryList {set; } 
    }
}
