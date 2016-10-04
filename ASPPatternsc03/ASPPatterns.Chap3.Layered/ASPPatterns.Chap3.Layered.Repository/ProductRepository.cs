using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap3.Layered.Model;   

namespace ASPPatterns.Chap3.Layered.Repository
{
    /// <summary>
    /// 数据访问层
    /// </summary>
    public class ProductRepository : IProductRepository 
    {        
        /// <summary>
        /// 通过 linq to sql 获取所有的商品
        /// 并创建一个Product业务实体列表将其返回
        /// </summary>
        /// <returns></returns>
        public IList<Model.Product> FindAll()
        {
            var products = from p in new ShopDataContext().Products
                           select new Model.Product
                               {
                                   Id = p.ProductId, 
                                   Name = p.ProductName,                                   
                                   Price = new Model.Price(p.RRP, p.SellingPrice)                                                                        
                               };            

            return products.ToList();
        }
     
    }
}
