using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Service
{
    public class ProductViewModel
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        public string RRP { get; set; }

        /// <summary>
        /// 卖价
        /// </summary>
        public string SellingPrice { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public string Discount { get; set; }

        /// <summary>
        /// 节约了
        /// </summary>
        public string Savings { get; set; }
    }
}
