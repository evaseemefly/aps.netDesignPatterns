using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap3.Layered.Service; 

namespace ASPPatterns.Chap3.Layered.Presentation
{
    /// <summary>
    /// 产品集合 呈现器
    /// </summary>
    public class ProductListPresenter
    {
        /// <summary>
        /// 
        /// </summary>
        private IProductListView _productListView;

        /// <summary>
        /// ASPPatterns.Chap3.Layered.Service.ProductService
        /// </summary>
        private Service.ProductService _productService;
                
        public ProductListPresenter(IProductListView ProductListView, Service.ProductService ProductService)
        {
            _productService = ProductService;
            _productListView = ProductListView;
        }

        public void Display()
        {
            ProductListRequest productListRequest = new ProductListRequest();
            productListRequest.CustomerType = _productListView.CustomerType;

            ProductListResponse productResponse = _productService.GetAllProductsFor(productListRequest);

            if (productResponse.Success)
            {
                _productListView.Display(productResponse.Products);
            }
            else 
            {
                _productListView.ErrorMessage = productResponse.Message; 
            }
   
        }
    }
}
