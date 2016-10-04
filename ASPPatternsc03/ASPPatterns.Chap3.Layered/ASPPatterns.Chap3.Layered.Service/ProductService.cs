using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap3.Layered.Service
{
    /// <summary>
    /// 服务层，将于领域模型服务交互
    /// </summary>
    public class ProductService
    {
        private Model.ProductService _productService;

        public ProductService(Model.ProductService ProductService)
        {
            _productService = ProductService;
        }

        public ProductListResponse GetAllProductsFor(ProductListRequest productListRequest)
        {
            //客户端发了一个请求，此时创建一个响应集合
            ProductListResponse productListResponse = new ProductListResponse();

            try
            {
                //为全部商品赋予指定的折扣策略
                IList<Model.Product> productEntities = _productService.GetAllProductsFor(productListRequest.CustomerType);

                productListResponse.Products = productEntities.ConvertToProductListViewModel();
                productListResponse.Success = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Log the exception...

                productListResponse.Success = false;
                // Return a friendly error message
                productListResponse.Message = "Check that your database is in the correct place. Hint: Check the AttachDbFilename section within App.config in the project ASPPatterns.Chap3.Layered.Repository.";
            }
            catch (Exception ex)
            {
                // Log the exception...

                productListResponse.Success = false;
                // Return a friendly error message
                productListResponse.Message = "An error occured";
            }

            return productListResponse;
        }

    }
}
