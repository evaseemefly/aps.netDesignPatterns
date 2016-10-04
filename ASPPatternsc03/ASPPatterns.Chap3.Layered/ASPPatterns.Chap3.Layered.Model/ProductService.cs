using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Model
{
    /// <summary>
    /// 客户端与领域交互的服务类——仍属于 业务层
    /// </summary>
    public class ProductService
    {
        /// <summary>
        /// 产品仓储对象
        /// </summary>
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 为全部产品赋予指定的折扣策略
        /// </summary>
        /// <param name="customerType"></param>
        /// <returns></returns>
        public IList<Product> GetAllProductsFor(CustomerType customerType)
        {
            //1 根据传入的值通过 工厂模式去创建对应的折扣策略
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategyFor(customerType);

            //2 获取产品仓库中的全部集合
            IList<Product> products = _productRepository.FindAll();

            //3 为产品仓库赋予折扣策略
            products.Apply(discountStrategy);

            return products;
        }    
    }
}
